using Microsoft.EntityFrameworkCore;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.EntityFrameworkCoreSQL
{
    public interface ILinksRepo
    {
        void AddLinks(Links newLink);

        Task<List<Links>> GetLinks();
    }

    public class LinksRepo : ILinksRepo
    {
        private readonly AppDbContext _context;

        public LinksRepo(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Links>> GetLinks()
        {
            return _context.Links.ToListAsync();
        }

        public void AddLinks(Links newLink)
        {
            try
            {
                _context.Add(newLink);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var localE = e;
                throw;
            }
        }
    }
}