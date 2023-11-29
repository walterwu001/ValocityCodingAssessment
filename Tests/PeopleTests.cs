using ReFactor;
using Xunit;

namespace Tests
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
        public void CreatePeopleWithNameAndDateOfBirth()
        {
            // Arrange
            string testName = "Alice";
            DateTime testDateOfBirth = new DateTime(1990, 5, 15);

            // Act
            var person = new Person(testName, testDateOfBirth);

            // Assert
            Assert.Equal(testName, person.Name);
            Assert.Equal(testDateOfBirth.Date, person.DateOfBirth.Date);
        }

        [Fact]
        public void DOBDefaultedToUnder16ForNameOnlyConstructor()
        {
            // Arrange
            string testName = "Bob";
            DateTimeOffset expectedDateOfBirth = DateTimeOffset.UtcNow.AddYears(-15).Date;

            // Act
            var person = new Person(testName);

            // Assert
            Assert.Equal(expectedDateOfBirth, person.DateOfBirth);
        }
    }
}

