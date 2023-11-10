namespace ABCDView.Models
{
    public class Student
    {
        public string Math { get; set; }
        public string English { get; set; }
        public string History { get; set; }
        public string Oracle { get; set; }
        public string Data { get; set; }    
    }
    public enum score
    {
        A_plus = 100,
        A = 95,
        B_plus =90,
        B = 80,
        C_plus =75,
        C = 70,
        D_plus =65,
        D = 60
        
    }
}
