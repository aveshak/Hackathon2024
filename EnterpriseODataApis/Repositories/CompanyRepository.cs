using Microsoft.EntityFrameworkCore;
using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class CompanyRepository
    {
        private readonly DataBaseContext _context;
        public CompanyRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies.Include(a => a.Products).AsQueryable();
        }

        public IQueryable<Company> GetById(int id)
        {
            return _context.Companies
                .Include(a => a.Products)
                .AsQueryable()
                .Where(c => c.Id == id);
        }
    }
}
