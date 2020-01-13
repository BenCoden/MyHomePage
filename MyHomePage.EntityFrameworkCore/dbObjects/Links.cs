using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL.dbObjects
{
    public interface ILinks
    {
        string BackgroundColor { get; set; }
        bool CanSearchSite { get; set; }
        int Id { get; set; }
        string ImageUrl { get; set; }
        bool InvertImageColors { get; set; }
        bool IsActive { get; set; }
        bool IsPined { get; set; }
        string Text { get; set; }
        string Url { get; set; }
    }

    public class DboLinks : ILinks
    {
        public bool IsActive { get; set; }
        public bool IsPined { get; set; }
        public bool CanSearchSite { get; set; }
        public int Id { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public bool InvertImageColors { get; set; }
        public string BackgroundColor { get; set; }
    }
}