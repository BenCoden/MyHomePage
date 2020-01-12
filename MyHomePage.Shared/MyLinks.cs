using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.Shared
{
    public interface IMyLinks
    {
        List<dboLinks> GetAllMyLinks();
    }

    public class MyLinks : IMyLinks
    {
        private readonly ITRepo<dboLinks> _linksRepo;

        public MyLinks(ITRepo<dboLinks> linkRepo)
        {
            _linksRepo = linkRepo;
        }

        public List<dboLinks> GetAllMyLinks()
        {
            var result = new List<dboLinks>();
            result = _linksRepo.GetLinks();
            return result;
        }
    }
}