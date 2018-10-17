using System;

namespace epicenterWin
{
    public class Person : MissingEntity
    {
        public string YML { get; set; }
        public SearchReason Reason { get; set; } = SearchReason.Missing;
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Reason = SearchReason.Missing;
        }
        public Person()
        {
        }
    }

    public enum SearchReason : int
    {
        Missing,
        Criminal,
        Other
    }
}