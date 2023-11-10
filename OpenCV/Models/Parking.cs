using System.ComponentModel.DataAnnotations;

namespace OpenCV.Models
{
    public class Parking
    {
        [Key]
        public int No { get; set; }
        [Required]
        public string Num { get; set; }
        [Required]
        public DateTime EnterDate { get; set; }
        [Required]
        public DateTime OutDate { get; set; }
        [Required]
        public DateTime Price { get; set; }
    }
}
