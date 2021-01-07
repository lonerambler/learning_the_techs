using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);

        void AddGrade(char letter);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(char letter);

        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0.0 && grade <= 100.0)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override void AddGrade(char letter)
        {
            if (letter >= 'A' && letter <= 'F')
            {
                switch (letter)
                {
                    case 'A':
                        AddGrade(90.0);
                        break;
                    case 'B':
                        AddGrade(80.0);
                        break;
                    case 'C':
                        AddGrade(70.0);
                        break;
                    default:
                        AddGrade(0.0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Letter Value");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.OperateGrade(grade);
            }

            return result;
        }

        public override event GradeAddedDelegate GradeAdded;

        private List<double> grades;
        private string name;

        public const string CATEGORY = "Science";
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
            gradesFileName = $"{name}.txt";
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0.0 && grade <= 100.0)
            {
                using (var writer = File.AppendText(gradesFileName))
                {
                    writer.WriteLine(grade);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override void AddGrade(char letter)
        {
            if (letter >= 'A' && letter <= 'F')
            {
                switch (letter)
                {
                    case 'A':
                        AddGrade(90.0);
                        break;
                    case 'B':
                        AddGrade(80.0);
                        break;
                    case 'C':
                        AddGrade(70.0);
                        break;
                    default:
                        AddGrade(0.0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Letter Value");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText(gradesFileName))
            {
                bool done = false;
                do
                {
                    string gradeRead = reader.ReadLine();

                    if (string.IsNullOrEmpty(gradeRead))
                    {
                        done = true;
                    }
                    else
                    {
                        result.OperateGrade(double.Parse(gradeRead));
                    }
                } while (!done);
            }

            return result;
        }

        public override event GradeAddedDelegate GradeAdded;
        private string gradesFileName;
        private string name;

        public const string CATEGORY = "Science";
    }
}
