namespace epicenterWin
{
    public abstract class MissingEntity : DbEntity
    {
        [CompositeKey]
        public string FirstName { get; set; }
        [CompositeKey]
        public string LastName { get; set; }

        public int Missing { get; set; } = 1;

        [UnecessaryColumn]
        public string FullName => $"{FirstName} {LastName}";
    }
}