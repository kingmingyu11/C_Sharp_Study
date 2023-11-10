using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApp_RE.Models
{
    public class User
    {
        
      
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Pw{ get; set; }

        [Required]
        public string Name { get; set; }
      
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public string Hp { get; set; }
    }
}
