namespace TagHelpers_Quiz.Models
{
    public class Student
    {
        public string ID{ get; set; }
        public string password { get; set; }

        public int title { get; set; }

        public string notice_board { get; set; }
        public string IsEmployed { get; set; }

        public Moon2 Moon2 { get; set; }
    }
    public enum Moon2
    {
        채팅_제한_문의,
        게임_이용_제한_문의,
        후순위_대기열_패널티_문의,
        Discuss_a_Chargeback_ban

    }

}
