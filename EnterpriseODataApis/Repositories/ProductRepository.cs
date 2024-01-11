using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class ProductRepository
    {
        private readonly DataBaseContext _context;
        public ProductRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.AsQueryable();
        }

        public IQueryable<Product> GetById(int id)
        {
            return _context.Products
                .AsQueryable()
                .Where(c => c.Id == id);
        }
    }
}
