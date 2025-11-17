using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;

namespace ChoreWheel.Backend.Services;

public class ConfirmationFileService(ILogger<ConfirmationFileService> logger) : IEmailSender
{
    private readonly ILogger _logger = logger;
    private readonly string _basePath = Path.Combine(Environment.CurrentDirectory, "ConfirmationEmails");

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        string fileName = email;
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '-');
        }
        await File.WriteAllTextAsync(Path.Combine(_basePath, $"{fileName}.html"), htmlMessage);
    }
}
