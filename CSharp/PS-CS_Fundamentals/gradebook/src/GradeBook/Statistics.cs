using System;

namespace GradeBook
{
    public class Statistics{
        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;
            Sum = 0.0;
        }

        public void OperateGrade(double grade)
        {
            Low = Math.Min(grade, Low);
            High = Math.Max(grade, High);

            Sum += grade;
            Count++;
        }

        public double Average
        {
            get
            {
                if(Count > 0)
                {
                    return Sum / Count;
                }

                return 0.0;
            }
        }
        public char Letter
        {
            get
            {
                switch(Average){
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    default:
                        return 'F';
                }
            }
        }
        public double High;
        public double Low;
        public int Count;
        public double Sum;
    }
}
