using System;

namespace epicenterWin
{
    public class Person : MissingEntity
    {
        public string YML { get; set; }
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public Person()
        {
        }
    }
}