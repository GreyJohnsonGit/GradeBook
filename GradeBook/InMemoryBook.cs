using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public const string CATEGORY = "Science";

        List<double> grades;

        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string _name) : base(_name)
        {
            grades = new List<double>() { };
        }

        public void AddGrade(char _grade)
        {
            switch (_grade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double _grade)
        {
            if(_grade >= 0 && _grade <= 100) 
            {
                grades.Add(_grade);
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(_grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            return new Statistics(grades);
        }
    }
}
