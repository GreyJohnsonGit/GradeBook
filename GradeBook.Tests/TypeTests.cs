using System;
using System.Runtime.InteropServices;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        [Fact]
        public void SharedReferenceToBookIsPossible()
        {
            var book1 = new InMemoryBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        }

        [Fact]
        public void BookNameIsNotShared()
        {
            var book1 = new InMemoryBook("Book 1");
            var book2 = new InMemoryBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
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

        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += ReturnMessage2;

            log("Hello");

            Assert.Equal(3, count);
        }

        string ReturnMessage(string msg)
        {
            count++;
            return msg;
        }

        string ReturnMessage2(string msg)
        {
            count++;
            return msg;
        }
    }
}
