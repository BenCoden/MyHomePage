using Microsoft.EntityFrameworkCore;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.EntityFrameworkCoreSQL
{
    public interface ITRepo<T> where T : class
    {
        void AddLinks(T arg);

        List<T> GetLinks();

        void UpdateLink(T arg);
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

        public void AddLinks(T arg)
        {
            try
            {
                _context.Add(arg);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var localE = e;
                throw;
            }
        }

        public void UpdateLink(T arg)
        {
            try
            {
                _context.Update(arg);
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