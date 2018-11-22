using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.Models.Abstract.MissingModel;

namespace WebApplication1.Infrastructure.Utils
{
    public static class SearchReasonMap 
    {
        public static Dictionary<SearchReason, string> reasonDictionary = 
            new Dictionary<SearchReason, string> {
                { SearchReason.NotSearched, "Not searched" },
                { SearchReason.Missing , "Mising"},
                { SearchReason.Criminal, "Criminal" },
                { SearchReason.Other, "Other" }
        };
    }
}
