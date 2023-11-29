using System;

namespace ReFactor
{
    public class Person
    {
        private const int Under16Years = 15;
        private static readonly DateTimeOffset DefaultDateOfBirth = DateTimeOffset.UtcNow.AddYears(-Under16Years);
        public string Name { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }

        /// <summary>
        /// Person
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Person</returns>
        public Person(string name) : this(name, DefaultDateOfBirth.Date)
        {
        }

        /// <summary>
        /// Person
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns>Person</returns>
        public Person(string name, DateTime dateOfBirth)
        {
            ValidateName(name);

            Name = name;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// ValidateName
        /// </summary>
        /// <param name="name"></param>
        /// <returns>void</returns>
        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
        }
    }
}
