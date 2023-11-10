using System.ComponentModel.DataAnnotations;

namespace MyDirayQuizStart.Models
{
    public class Diary
    {
        [Key]
        public int No { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
