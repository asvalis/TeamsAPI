using System.ComponentModel.DataAnnotations;

namespace TeamsAPI.Models
{
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
