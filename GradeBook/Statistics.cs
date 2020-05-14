using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net;

namespace GradeBook
{
    public class Statistics
    {
        public double Minimum;
        public double Maximum;
        public double Average
        {
            get 
            { 
                return count != 0 ? sum / count : 0; 
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case double avg when avg >= 90: return 'A';
                    case double avg when avg >= 80: return 'B';
                    case double avg when avg >= 70: return 'C';
                    case double avg when avg >= 60: return 'D';
                    default: return 'F';
                }
            }
        }

        private double sum;
        private double count;

        public Statistics()
        {
            Minimum = Double.MaxValue;
            Maximum = Double.MinValue;
            sum = 0;
            count = 0;
        }

        public Statistics(List<double> _grades) : this()
        { 
            if (_grades != null && _grades.Count != 0)
            {
                foreach (double grade in _grades)
                {
                    Add(grade);
                }
            }
        }

        public void Add(double _grade)
        {
            if (_grade >= 0 && _grade <= 100)
            {
                sum += _grade;
                count++;
                Minimum = Math.Min(_grade, Minimum);
                Maximum = Math.Max(_grade, Maximum);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(_grade)}");
            }
            
        }
    }
}
