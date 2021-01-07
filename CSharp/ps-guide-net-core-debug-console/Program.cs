using System;
using Bogus;

namespace DebugNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Bogus.Faker();
            var ticket = new Ticket
            {
                TicketId = faker.UniqueIndex,
                BasePrice = 200.0m,
                PremiumFee = 25.0m,
                IsPremium = true
            };
            Console.WriteLine(ticket);
        }
    }
}
