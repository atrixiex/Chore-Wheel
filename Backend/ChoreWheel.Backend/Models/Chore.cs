using Microsoft.AspNetCore.Identity;

namespace ChoreWheel.Backend.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        /*
        public string Description { get; set; } = string.Empty;
        public required int Time { get; set; } = 5;
        public required ChoreDifficulty Difficulty { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime StartOn { get; set; } = DateTime.Now;
        public int DaysBeforeNext { get; set; } = 7;
        */
        public required IdentityUser OwnedBy { get; set; }
        public ICollection<IdentityUser> SharedWith { get; set; } = [];
    }
}
