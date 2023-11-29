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
        private List<Person> _persons;

        public BirthingUnit()
        {
            _persons = new List<Person>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<Person> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _persons.Add(new Person(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _persons;
        }

        private IEnumerable<Person> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _persons.Where(x => x.Name == "Bob" && x.DateOfBirth >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _persons.Where(x => x.Name == "Bob");
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