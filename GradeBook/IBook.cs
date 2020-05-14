using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public interface IBook
    {
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
       
        void AddGrade(double _grade);
        Statistics GetStatistics();
    }
}