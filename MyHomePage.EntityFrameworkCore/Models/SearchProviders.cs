using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL.Models
{
    public class SearchProviders
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string SearchUrl { get; set; }
        public bool IsDefault { get; set; }
    }
}