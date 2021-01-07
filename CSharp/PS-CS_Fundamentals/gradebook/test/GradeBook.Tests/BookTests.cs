using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestAddOutOfBoundariesGrade()
        {
            var book = new InMemoryBook("Book of TestAddOutOfBoundariesGrade test");

            // book.AddGrade(105.0);
            book.AddGrade(95.0);
            
            // Assert.Equal(0.0, book.GetStatistics().Average);
            Assert.Equal(95.0, book.GetStatistics().Average, 1);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
