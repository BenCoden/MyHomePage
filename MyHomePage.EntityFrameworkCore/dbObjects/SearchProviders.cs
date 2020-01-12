using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL.dbObjects
{
    public interface ISearchProviders
    {
        string DisplayName { get; set; }
        int Id { get; set; }
        bool IsDefault { get; set; }
        string SearchUrl { get; set; }
    }

    public class dboSearchProviders : ISearchProviders
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string SearchUrl { get; set; }
        public bool IsDefault { get; set; }
    }
}