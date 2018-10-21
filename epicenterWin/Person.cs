using System;

namespace epicenterWin
{
    public class Person : MissingEntity, IEquatable<Person>
    {
        public string YML { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {
        }

        public bool Equals(Person other)
        {
            return FullName == other.FullName;
        }
    }
}