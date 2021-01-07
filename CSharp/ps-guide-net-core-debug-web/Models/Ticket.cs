namespace DebugWebApp.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal PremiumFee { get; set; }
        public bool IsPremium { get; set; }
    }
}