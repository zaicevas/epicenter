using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epicenter.Domain.Models.Abstract
{
    public class MissingModel : Model
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason Reason { get; set; } = SearchReason.Missing;
        public byte[] BaseImage { get; set; }

        public ICollection<Timestamp> Timestamps { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public enum SearchReason : int
        {
            NotSearched,
            Missing,
            Criminal,
            Other
        }
    }
}
