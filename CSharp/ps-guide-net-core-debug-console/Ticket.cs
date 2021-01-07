using System;

namespace DebugNetCore
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal PremiumFee { get; set; }
        public bool IsPremium { get; set; }
        public Attendee Attendee { get; set; }

        public override String ToString()
        {
            return $"<Ticket Id: {TicketId.ToString()} Attendee: {Attendee.FirstName} {Attendee.LastName} {(IsPremium ? "Premium" : String.Empty)}>";
        }
    }
}