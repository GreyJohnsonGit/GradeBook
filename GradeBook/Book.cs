using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string _name) : base(_name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double _grade);

        public abstract Statistics GetStatistics();
    }
}
