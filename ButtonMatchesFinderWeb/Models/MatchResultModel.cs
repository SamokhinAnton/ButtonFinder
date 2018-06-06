using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButtonMatchesFinderWeb.Models
{
    public class MatchResultModel
    {
        public HtmlNode Element { get; set; }

        public Dictionary<string, string> MatchParams { get; set; }
    }
}
