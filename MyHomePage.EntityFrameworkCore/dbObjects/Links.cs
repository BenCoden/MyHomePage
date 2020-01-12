using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL.dbObjects
{
    public interface ILinks
    {
        string BackgroundColor { get; set; }
        string ImageUrl { get; set; }
        bool InvertImageColors { get; set; }
        string Text { get; set; }
        string Url { get; set; }
        int Id { get; }
    }

    public class dboLinks : ILinks
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public bool InvertImageColors { get; set; }
        public string BackgroundColor { get; set; }
    }
}