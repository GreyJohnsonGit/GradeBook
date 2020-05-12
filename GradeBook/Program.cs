using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book;
            double numGrade;
            char letGrade;
            string input;

            Console.WriteLine("Please Enter GradeBook Name:");
            book = new Book(Console.ReadLine());

            bool done = false;
            while(!done)
            {
                Console.WriteLine("Please Enter New Grade (Q to Display Statistics):");
                input = Console.ReadLine();
                if (input == "Q")
                {
                    done = true;
                }
                else if (double.TryParse(input, out numGrade))
                {
                    try
                    {
                        book.AddGrade(numGrade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (char.TryParse(input, out letGrade) && ((letGrade >= 'A' && letGrade <= 'D') || (letGrade == 'F')))
                {
                    book.AddLetterGrade(letGrade);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            Statistics stats = book.GetStatistics();
            Console.WriteLine($"{book.GetName()}:\nLETTER: {stats.Letter} | AVG: {stats.Average:N2} | MIN: {stats.Minimum:N2} | MAX {stats.Maximum:N2}");
        }
    }
}
