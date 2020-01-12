using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.EntityFrameworkCoreSQL
{
    public interface ITRepo<T> where T : class
    {
        void AddLinks(T newLink);

        List<T> GetLinks();
    }

    public class TRepo<T> : ITRepo<T> where T : class
    {
        private readonly AppDbContext _context;

        public TRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<T> GetLinks()
        {
            return _context.Set<T>().ToList();
        }

        public void AddLinks(T newLink)
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