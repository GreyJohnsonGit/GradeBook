using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string _name) : base(_name) {}

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double _grade)
        {
            using (var fileWriter = File.AppendText($"{Name}.txt"))
            {
                fileWriter.Write(_grade + "|");
                GradeAdded?.Invoke(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var grades = new List<double>() { };

            string text = File.ReadAllText($"{Name}.txt");
            if (text != null)
            {
                //Split, ignore final empty string, map strings to double, convert array to List
                grades = text.Split("|").SkipLast(1).Select(double.Parse).ToList();
            }
            
            return new Statistics(grades);
        }
    }
}
