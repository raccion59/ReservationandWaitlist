namespace WebApplication2.Models
{
    public class Business
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string District { get; set; }
        public int PriceRating { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int Capacity { get; set; }
        public double rating { get; set; }
        public BusinesType Type { get; set; }
        public bool isActive { get; set; }

        public List<Category> Categories { get; set; }
        public List<Photo> Photos { get; set; }
        public string Menu { get; set; }

        public List<Faq> Faqs { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
