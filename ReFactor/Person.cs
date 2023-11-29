using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class Person
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }
        public Person(string name) : this(name, Under16.Date)
        {
        }
        public Person(string name, DateTime dob)
        {
            Name = name;
            DateOfBirth = dob;
        }
    }
}
