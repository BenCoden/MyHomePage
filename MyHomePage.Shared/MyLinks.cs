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
        Task<List<Links>> GetAllMyLinks();
    }

    public class MyLinks : IMyLinks
    {
        private readonly ILinksRepo _linksRepo;

        public MyLinks(ILinksRepo linkRepo)
        {
            _linksRepo = linkRepo;
        }

        public async Task<List<Links>> GetAllMyLinks()
        {
            var result = new List<Links>();
            result = await _linksRepo.GetLinks();
            return result;
        }
    }
}