using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Attributes.Database;

namespace WebApplication1.Models.Abstract
{
    public class MissingModel : Model
    {
        [CompositeKey]
        public string FirstName { get; set; }
        [CompositeKey]
        public string LastName { get; set; }

        public SearchReason Reason { get; set; } = SearchReason.Missing;

        [NonDatabase]
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
