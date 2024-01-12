using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class EventCategoryRepository
    {
        private readonly DataBaseContext _context;
        public EventCategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<EventCategory> GetAll()
        {
            return _context.EventCategories.AsQueryable();
        }

        public IQueryable<EventCategory> GetById(int id)
        {
            return _context.EventCategories
                .AsQueryable()
                .Where(ec => ec.Id == id);
        }
    }
}
