namespace WebApplication2.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Roles { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool isActive { get; set; }
    }
}
