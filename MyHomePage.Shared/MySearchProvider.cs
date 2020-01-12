using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.Shared
{
    public interface IMySearchProvider
    {
        List<dboSearchProviders> GetSearchProviders();
    }

    public class MySearchProvider : IMySearchProvider
    {
        private ITRepo<dboSearchProviders> _spRepo;

        public MySearchProvider(ITRepo<dboSearchProviders> spRepo)
        {
            _spRepo = spRepo;
        }

        public List<dboSearchProviders> GetSearchProviders()
        {
            var result = _spRepo.GetLinks();

            return result;
        }
    }
}