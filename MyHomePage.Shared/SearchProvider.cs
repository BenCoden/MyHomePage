using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.Shared
{
    public interface ISearchProvider
    {
        string DisplayName { get; set; }
        bool IsDefault { get; set; }
        string SearchUrl { get; set; }
    }

    public class SearchProvider : ISearchProvider
    {
        public string DisplayName { get; set; }
        public string SearchUrl { get; set; }
        public bool IsDefault { get; set; }
    }
}