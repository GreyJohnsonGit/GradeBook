using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.00, 11.00, 12.00, 44.12, 100.00 };
            
            Book book = new Book("Nemo's Gradebook");
            foreach (var grade in grades)
            {
                book.AddGrade(grade);
            }

            Statistics stats = book.GetStatistics();
        }
    }

    public class Book
    {
        private string name;
        private List<double> grades;

        public Book()
        {
            grades = new List<double>() {};
        }

        public Book(string _name) : this()
        {
            this.name = _name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics() {
            var stats = new Statistics();

            if (grades.Count == 0)
            {
                stats.Initialize(0, 0, 0);
            }
            else {
                stats.Initialize(double.MaxValue, double.MinValue, 0);

                double sum = 0;
                foreach (var grade in grades)
                {
                    sum += grade;
                    stats.UpdateMinMax(grade);
                }

                stats.SetAvg(sum / grades.Count);
            }

            return stats;
        }
    }
}
