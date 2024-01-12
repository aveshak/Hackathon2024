using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class AccountRepository
    {
        private readonly DataBaseContext _context;
        public AccountRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<Account> GetAll()
        {
            return _context.Account.AsQueryable();
        }

        public IQueryable<Account> GetById(int id)
        {
            return _context.Account
                .AsQueryable()
                .Where(a => a.Id == id);
        }
    }
}
