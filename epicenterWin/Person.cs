using System;

namespace epicenterWin
{
    public class Person : MissingEntity
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
    }
}