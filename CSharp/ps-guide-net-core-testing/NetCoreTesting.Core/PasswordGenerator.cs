using System;
using System.Text;

namespace NetCoreTesting.Core
{
    public class PasswordGenerator
    {
        public int MinLength { get; set; }

        public PasswordGenerator(int minLength = 8)
        {
            MinLength = minLength;
        }

        public string Generate()
        {
            if(MinLength < 0)
            {
                throw new ArgumentOutOfRangeException("MinLength", "Password length cannot be negative");
            }

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars += chars.ToLower();
            chars += "0123456789";

            var rnd = new Random();

            var password = new StringBuilder();

            for (var i = 0; i < MinLength; i += 1)
            {
                var position = rnd.Next(0, chars.Length);
                password.Append(chars[position]); 
            }

            return password.ToString();
        }
    }
}
