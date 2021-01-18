using System;

namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Pop by Largest Final.csv";
            CSVReader reader = new CSVReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach(Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            /*
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "Wensday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            daysOfWeek[2] = "Wednesday";

            foreach(string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            Console.WriteLine("Which day do you want to display?");
            Console.Write("(Monday = 1, etc.) > ");
            int iDay = int.Parse(Console.ReadLine());

            string chosenDay = daysOfWeek[iDay - 1];
            Console.WriteLine($"That day is {chosenDay}");
            */
        }
    }
}
