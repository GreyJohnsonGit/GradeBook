using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void SharedReferenceToBookIsPossible()
        {
            var book1 = new Book("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.Equal("Book 1", book1.GetName());
            Assert.Equal("Book 1", book2.GetName());
        }

        [Fact]
        public void BookNameIsNotShared()
        {
            var book1 = new Book("Book 1");
            var book2 = new Book("Book 2");

            Assert.Equal("Book 1", book1.GetName());
            Assert.Equal("Book 2", book2.GetName());
        }

        [Fact]
        public void SetNameWorks()
        {
            var book1 = new Book("Book 1");
            book1.SetName("New Name");

            Assert.Equal("New Name", book1.GetName());
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = new Book("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.GetName());
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book();
            book.SetName(name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = new Book("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.GetName());
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book();
            book.SetName(name);
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string str = "Grey";
            string upper = "";
            upper = MakeUpper(str);

            Assert.Equal("Grey", str);
            Assert.Equal("GREY", upper);
        }

        private string MakeUpper(string str)
        {
            return str.ToUpper();
        }
    }
}
