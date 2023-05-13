namespace WebApplication2.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Business Business { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public int Pax { get; set; }
        public ReservationStatus Status { get; set; }

    }
}
