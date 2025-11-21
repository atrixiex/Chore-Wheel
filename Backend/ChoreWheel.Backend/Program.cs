using ChoreWheel.Backend.Data;
using ChoreWheel.Backend.Data.Database;
using ChoreWheel.Backend.Data.Identity;
using ChoreWheel.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Auth
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddUserManager<ApplicationUserManager>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserContextProvider, UserContextProvider>();
builder.Services.AddControllers();
builder.Services.AddTransient<IEmailSender, ConfirmationFileSender>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Add identity endpoints
app.MapIdentityApi<IdentityUser>();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Seed roles, users, and chores
    await DataSeeder.SeedDatabase(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        //options.AddPreferredSecuritySchemes("BearerAuth");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
