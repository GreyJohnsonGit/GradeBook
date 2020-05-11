using System;
using System.Data.SqlTypes;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void addGradeTest()
        {
            Book book;
            Statistics stats;

            book = new Book();
            book.AddGrade(20);
            book.AddGrade(0);
            book.AddGrade(100);
            stats = book.GetStatistics();

            Assert.Equal(0, stats.Minimum);
            Assert.Equal(100, stats.Maximum);
            Assert.Equal(40, stats.Average);
        }
    }
}
