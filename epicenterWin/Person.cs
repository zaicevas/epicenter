namespace epicenterWin
{
    public class Person : MissingEntity
    {
        public string YML { get; set; }
        public SearchReason Reason { get; set; }
        public Person(string firstName, string lastName)
        {
            FirstName = FirstName;
            LastName = LastName;
            Reason = SearchReason.Missing;
        }
        public Person()
        {
            Reason = SearchReason.Missing;
        }
    }

    public enum SearchReason : int
    {
        Missing,
        Criminal,
        Other
    }
}