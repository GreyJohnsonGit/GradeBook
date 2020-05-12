using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            Book book;
            Statistics stats;

            book = new Book();
            book.AddGrade(100);
            book.AddGrade(50);
            book.AddGrade(75);
            stats = book.GetStatistics();

            Assert.Equal(50, stats.Minimum);
            Assert.Equal(100, stats.Maximum);
            Assert.Equal(75, stats.Average);
            Assert.Equal('C', stats.Letter);
        }

        [Fact]
        public void CheckGradeBounds()
        {
            Book book;
            Statistics stats;

            book = new Book();

            book.AddGrade(32);
            book.AddGrade(0);
            try
            {
                book.AddGrade(-10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            book.AddGrade(64);
            book.AddGrade(100);
            try
            {
                book.AddGrade(110);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            stats = book.GetStatistics();

            Assert.Equal(0, stats.Minimum);
            Assert.Equal(100, stats.Maximum);
        }
    }
}
