namespace WebApplication2.Models
{
    public class Review
    {
        public int id { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }

        public int Overall { get; set; }
        public int Food { get; set; }
        public int Service { get; set; }
        public int Ambience { get; set; }

    }
}
