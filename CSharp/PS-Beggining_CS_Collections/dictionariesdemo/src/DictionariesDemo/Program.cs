using System;
using System.Collections.Generic;

namespace DictionariesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Pop by Largest Final.csv";
            CSVReader reader = new CSVReader(filePath);

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country do you want to look up? ");
            string userInput = Console.ReadLine();

            if(countries.TryGetValue(userInput, out Country country))
                Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}.");
            else
                Console.WriteLine($"Sorry, there is no country with code \"{userInput}\".");
        }
    }
}
