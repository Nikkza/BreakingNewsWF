﻿using System.Text.RegularExpressions;

namespace BreakingNewsWF
{
    public class WebCalCulator : IWebCalCulator
    {
        public int CalculateNumberOfHits(IWebColector webColl, string keyword)
        {
            if (webColl == null || string.IsNullOrEmpty(webColl.HtmlCode) || string.IsNullOrEmpty(keyword))
            {
                return -1;
            }
            return Regex.Matches(webColl.HtmlCode.ToLower(), keyword).Count;
        }
    }
}
