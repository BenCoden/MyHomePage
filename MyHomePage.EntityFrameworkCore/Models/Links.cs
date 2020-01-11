using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL.Models
{
    public class Links
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public bool InvertImageColors { get; set; }
        public string BackgroundColor { get; set; }
    }
}