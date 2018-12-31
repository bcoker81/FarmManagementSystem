using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    public class SearchModel
    {
        public string SearchString { get; set; }
        public SearchSelectionType SearchType { get; set; }
    }
}