namespace epicenterWin
{
    public class Person : MissingEntity
    {
        public string YML { get; set; }
        public SearchReason reason;
        public Person(string firstName, string lastName)
        {
            FirstName = FirstName;
            LastName = LastName;
            reason = SearchReason.Missing;
        }
        public Person()
        {
            reason = SearchReason.Missing;
        }
    }

    public enum SearchReason : int
    {
        Missing,
        Criminal,
        Other
    }
}