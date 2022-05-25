using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TeamsAPI.Models
{
    [Index("firstName", "lastName", IsUnique = true, Name = "IX_FirstAndLastName")]
    public class Player
    {
        [Key]
        public int id { get; private set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public int Teamid { get; set; }
    }
}
