using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApplication1.Models.OpenALPR.Responses
{
    public class PlateAPIResponse
    {
        public List<PlateAPIResult> Results { get; set; }

        public void UpdateMatchesPattern(string pattern)
        {
            Regex regex = new Regex(pattern);
            Results.ForEach(result => result.MatchesPattern = regex.IsMatch(result.Plate));
        }
    }
}
