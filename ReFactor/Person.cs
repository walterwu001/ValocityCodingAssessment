using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class Person
    {
        private const int Under16Years = 15;
        private static readonly DateTimeOffset DefaultDOB = DateTimeOffset.UtcNow.AddYears(-Under16Years);
        public string Name { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }
        public Person(string name) : this(name, DefaultDOB.Date)
        {
        }
        public Person(string name, DateTime dateOfBirth)
        {
            ValidateName(name);

            Name = name;
            DateOfBirth = dateOfBirth;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
        }
    }
}
