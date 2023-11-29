using CodingAssessment.Refactor;
using Xunit;

namespace CodingAssessment.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void CreatePeopleWithNameOnly()
        {
            // Arrange
            string testName = "John";

            // Act
            var person = new Person(testName);

            // Assert
            Assert.Equal(testName, person.Name);
            Assert.True(person.DateOfBirth <= DateTimeOffset.UtcNow.Date);
        }

        [Fact]
        public void CreatePeopleWithNameAndDOB()
        {
            // Arrange
            string testName = "Alice";
            DateTime testDOB = new DateTime(1990, 5, 15);

            // Act
            var person = new Person(testName, testDOB);

            // Assert
            Assert.Equal(testName, person.Name);
            Assert.Equal(testDOB.Date, person.DateOfBirth.Date);
        }

        [Fact]
        public void DOBDefaultedToUnder16ForNameOnlyConstructor()
        {
            // Arrange
            string testName = "Bob";
            DateTimeOffset expectedDOB = DateTimeOffset.UtcNow.AddYears(-15).Date;

            // Act
            var person = new Person(testName);

            // Assert
            Assert.Equal(expectedDOB, person.DateOfBirth);
        }
    }
}

