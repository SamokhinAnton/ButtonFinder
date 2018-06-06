using ButtonMatchesFinderWeb.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButtonMatchesFinderWeb.Services
{
    public interface IFinderService
    {
        MatchResultModel Find(IEnumerable<HtmlNode> nodes, HtmlNode originNode);
    }
}
