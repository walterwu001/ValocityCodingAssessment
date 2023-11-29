using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private readonly List<Person> _persons = new();

        /// <summary>
        /// GetPersons
        /// </summary>
        /// <param name="count"></param>
        /// <returns>List<object></returns>
        public List<Person> GetPersons(int count)
        {
            var random = new Random();
            var newPersons = new List<Person>();

            for (int j = 0; j < count; j++)
            {
                string name = random.Next(0, 2) == 0 ? "Bob" : "Betty";
                DateTime dateOfBirth = DateTime.UtcNow.Subtract(TimeSpan.FromDays(random.Next(18 * 365, 85 * 365)));

                var person = new Person(name, dateOfBirth);
                newPersons.Add(person);
            }

            _persons.AddRange(newPersons);
            return newPersons;
        }

        private IEnumerable<Person> GetBobs(bool olderThan30)
        {
            var bobs = _persons.Where(x => x.Name == "Bob");

            if (olderThan30)
            {
                var thirtyYearsAgo = DateTime.UtcNow.AddYears(-30);
                bobs = bobs.Where(x => x.DateOfBirth <= thirtyYearsAgo);
            }

            return bobs;
        }

        public string GetMarried(Person person, string lastName)
        {
            if (lastName.Contains("test"))
            {
                return person.Name;
            }

            string fullName = $"{person.Name} {lastName}";

            if (fullName.Length > 255)
            {
                return fullName.Substring(0, 255);
            }

            return fullName;
        }
    }
}