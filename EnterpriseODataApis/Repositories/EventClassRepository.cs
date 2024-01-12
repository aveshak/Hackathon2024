using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class EventClassRepository
    {
        private readonly DataBaseContext _context;
        public EventClassRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<EventClass> GetAll()
        {
            return _context.EventClass.AsQueryable();
        }

        public IQueryable<EventClass> GetById(int id)
        {
            return _context.EventClass
                .AsQueryable()
                .Where(a => a.Id == id);
        }
    }
}
