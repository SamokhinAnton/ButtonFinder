using ButtonMatchesFinderWeb.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButtonMatchesFinderWeb.Services
{
    public class FinderService : IFinderService
    {
        public MatchResultModel Find(IEnumerable<HtmlNode> nodes, HtmlNode originNode)
        {
            var result = new MatchResultModel();
            int maxMatches = 0;

            foreach (var node in nodes)
            {
                int matchCount = 0;
                Dictionary<string, string> matchParams = new Dictionary<string, string>();
                foreach (var originalAttribute in originNode.Attributes)
                {
                    if (node.Attributes.Contains(originalAttribute.Name) && string.Equals(node.Attributes[originalAttribute.Name].Value, originalAttribute.Value))
                    {
                        matchParams.Add(originalAttribute.Name, originalAttribute.Value);
                        matchCount++;
                    }
                        
                }

                if (string.Equals(node.Name, originNode.Name))
                {
                    matchParams.Add("TagName", node.Name);
                    matchCount++;
                }
                    

                if (string.Equals(node.InnerText.Trim(), originNode.InnerText.Trim()))
                {
                    matchParams.Add("Text", originNode.InnerText.Trim());
                    matchCount++;
                }
                    

                if (matchCount > maxMatches && matchCount > 2)
                {
                    maxMatches = matchCount;
                    result.Element = node;
                    result.MatchParams = matchParams;
                }
            }

            return result;
        }
    }
}
