using System.ComponentModel.DataAnnotations;

namespace ValidationAtribute01.Models
{
    public class Student
    {
        // [Required]
        //[Required(ErrorMessage ="이름을 작성해주세요.")]
        [StringLength(15,MinimumLength =2,ErrorMessage ="이름은 두자 이상 작성이 가능합니다.")]

        public string Name { get; set; }

    }
}
