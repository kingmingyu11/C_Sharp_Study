using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imagetest.Models
{
    public class ImageEntity 
    {
       public int ImageId { get; set; }

        [Required]
        [Column(TypeName = "varbinary(max)")]
        public byte[] ImageData { get; set; }
    }
}
