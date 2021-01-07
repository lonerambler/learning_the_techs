using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Book  book0 = new InMemoryBook("Mikes In Memory Grade Book");
            // Book? book0 = new InMemoryBook("Mikes In Memory Grade Book");
            IBook book = new DiskBook("Mikes Disk-Stored Grade Book");
            book.GradeAdded += OnGradeAdded;
            /*book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;*/

            EnterGrades(book);

            var stats = book.GetStatistics();

            // Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the book names {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        // private static void EnterGrades(IBook? book)
        private static void EnterGrades(IBook book)
        {
            var lastInput = "";
            do
            {
                Console.Write("Please enter a Grade ('Q' to quit): ");
                lastInput = Console.ReadLine();

                char[] lastInputChar = lastInput.ToCharArray();

                if (lastInputChar[0] >= 'A' && lastInputChar[0] <= 'Z')
                {
                    if (lastInputChar[0] != 'Q')
                    {
                        book.AddGrade(lastInputChar[0]);
                    }
                }
                else
                {
                    try
                    {
                        book.AddGrade(double.Parse(lastInput));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }
                }
            } while (lastInput != "Q");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
