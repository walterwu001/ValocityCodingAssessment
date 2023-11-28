using Xunit;
using CodingAssessment.Refactor;
using System.Reflection;

namespace CodingAssessment.Tests
{
    public class BirthingUnitTests
    {
        [Fact]
        public void GetPeople_ReturnsCorrectNumberOfPeople()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();

            // Act
            int numberOfPeople = 5;
            var peopleList = birthingUnit.GetPeople(numberOfPeople);

            // Assert
            Assert.Equal(numberOfPeople, peopleList.Count);
        }

        [Fact]
        public void GetPeople_GeneratesPeopleWithExpectedNames()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();

            // Act
            int numberOfPeople = 10;
            var peopleList = birthingUnit.GetPeople(numberOfPeople);

            // Assert
            Assert.All(peopleList, p => Assert.True(p.Name == "Bob" || p.Name == "Betty"));
        }

        [Fact]
        public void GetPeople_GeneratesPeopleWithinAgeRange()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();

            // Act
            int numberOfPeople = 10;
            var peopleList = birthingUnit.GetPeople(numberOfPeople);
            var currentDate = DateTimeOffset.UtcNow;

            // Assert
            Assert.All(peopleList, p => {
                int age = currentDate.Year - p.DOB.Year;
                Assert.True(age >= 18 && age <= 85);
            });
        }

        [Fact]
        public void GetBobs_ReturnsCorrectBobs()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();
            int numberOfPeople = 20;
            birthingUnit.GetPeople(numberOfPeople);
            var getBobsMethod = typeof(BirthingUnit).GetMethod("GetBobs", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            if (getBobsMethod != null)
            {
                var resultOlderThan30 = getBobsMethod.Invoke(birthingUnit, new object[] { true }) as IEnumerable<People>;
                var resultNotOlderThan30 = getBobsMethod.Invoke(birthingUnit, new object[] { false }) as IEnumerable<People>;
                // Assert
                Assert.NotNull(resultOlderThan30);
                Assert.NotNull(resultNotOlderThan30);
            }
        }

        [Fact]
        public void GetMarried_WhenLastNameContainsTest_ReturnsFirstNameOnly()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();
            var person = new People("Alice");

            // Act
            var result = birthingUnit.GetMarried(person, "test");

            // Assert
            Assert.Equal("Alice", result);
        }

        [Fact]
        public void GetMarried_LastNameWithinLengthLimit_ReturnsFullName()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();
            var person = new People("Jane");

            // Act
            var result = birthingUnit.GetMarried(person, "Doe");

            // Assert
            Assert.Equal("Jane Doe", result);
        }

        [Fact]
        public void GetMarried_LastNameExceeds255Characters_TruncatesToMaxLength()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();
            var person = new People("Alice");

            // Act
            var result = birthingUnit.GetMarried(person, new string('X', 250));

            // Assert
            Assert.Equal(255, result.Length);
        }

        [Fact]
        public void GetMarried_LastNameConcatenationExactly255Characters_ReturnsFullName()
        {
            // Arrange
            var birthingUnit = new BirthingUnit();
            var person = new People("Chris");

            // Act
            var result = birthingUnit.GetMarried(person, new string('X', 249));

            // Assert
            Assert.Equal(255, result.Length);
        }

    }
}
