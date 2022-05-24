using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TeamsAPI.Models
{
    [Index(nameof(name), IsUnique = true), Index(nameof(location), IsUnique = true)]
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
