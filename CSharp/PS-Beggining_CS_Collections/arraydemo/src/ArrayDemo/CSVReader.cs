using System.IO;

namespace ArrayDemo
{
    class CSVReader
    {
        private string _csvFilePath;

        public CSVReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                for(int i = 0; i < nCountries; i++)
                {
                    string csvLine = sr.ReadLine();
                    countries[i] = ReadCountryFromCSVLine(csvLine);
                }
            }

            return countries;
        }

        public Country ReadCountryFromCSVLine(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] {','});

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}