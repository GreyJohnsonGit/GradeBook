using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        string name;
        List<double> grades;

        public Book()
        {
            grades = new List<double>() { };
        }

        public Book(string _name) : this()
        {
            this.name = _name;
        }

        public void AddLetterGrade(char _grade)
        {
            switch (_grade)
            {
                case 'A':
                    grades.Add(90);
                    break;
                case 'B':
                    grades.Add(80);
                    break;
                case 'C':
                    grades.Add(70);
                    break;
                case 'D':
                    grades.Add(60);
                    break;
                default:
                    grades.Add(0);
                    break;
            }
        }

        public void AddGrade(double _grade)
        {
            if(_grade >= 0 && _grade <= 100) 
            {
                grades.Add(_grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(_grade)}");
            }
        }

        public void SetName(string _name)
        {
            this.name = _name;
        }

        public string GetName()
        {
            return name;
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics();

            if (grades.Count == 0)
            {
                stats.Initialize(0, 0, 0);
            }
            else
            {
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
