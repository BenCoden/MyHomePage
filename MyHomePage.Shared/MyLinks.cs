using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using MyHomePage.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.Shared
{
    public interface IMyLinks
    {
        List<DboLinks> GetAllMyLinks();

        void UpdateLink(UserLinkViewModel userLink);
    }

    public class MyLinks : IMyLinks
    {
        private readonly ITRepo<DboLinks> _linksRepo;

        public MyLinks(ITRepo<DboLinks> linkRepo)
        {
            _linksRepo = linkRepo;
        }

        public List<DboLinks> GetAllMyLinks()
        {
            var result = new List<DboLinks>();
            result = _linksRepo.GetLinks();
            result = result.FindAll(find => find.IsActive);
            return result;
        }

        public void UpdateLink(UserLinkViewModel userLink)
        {
            _linksRepo.UpdateLink((DboLinks)userLink.UserLink);
        }
    }
}