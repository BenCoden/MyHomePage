using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL.dbObjects
{
    public interface IdboSearchProviders
    {
        string DisplayName { get; set; }
        int Id { get; set; }
        bool IsDefault { get; set; }
        string SearchUrl { get; set; }
    }

    public class dboSearchProviders : IdboSearchProviders
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string SearchUrl { get; set; }
        public bool IsDefault { get; set; }
    }
}