using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epicenter.Domain.Models.Abstract
{
    public class MissingModel : Model
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason Reason { get; set; } = SearchReason.Missing;

        [JsonIgnore]
        public ICollection<Timestamp> Timestamps { get; set; }

        [JsonIgnore]
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
