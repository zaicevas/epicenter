using System;

namespace epicenterWin
{
    public abstract class MissingEntity : DbEntity
    {
        [CompositeKey]
        public string FirstName { get; set; }
        [CompositeKey]
        public string LastName { get; set; }

        public SearchReason Reason { get; set; } = SearchReason.Missing;

        [UnecessaryColumn]
        public string FullName => $"{FirstName} {LastName}";

        [Flags]                        
        public enum SearchReason : int
        {               
            // flags represent priority
            NotSearched = 0,
            Missing = 1 << 0, 
            Criminal = 1 << 1,
            Other = 1 << 2
        }
    }
}