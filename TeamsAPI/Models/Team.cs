using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TeamsAPI.Models
{
    [Index("name", "location", IsUnique = true, Name = "IX_NameAndLocation")]
    public class Team
    {
        [Key]
        public int id { get; private set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string location { get; set; }
        public virtual List<Player?> players { get; set; } = new List<Player?>();
    }
}
