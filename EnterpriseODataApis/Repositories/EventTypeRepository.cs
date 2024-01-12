using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class EventTypeRepository
    {
        private readonly DataBaseContext _context;
        public EventStatusRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<EventType> GetAll()
        {
            return _context.EventType.AsQueryable();
        }

        public IQueryable<EventType> GetById(int id)
        {
            return _context.EventType
                .AsQueryable()
                .Where(et => et.Id == id);
        }
    }
}
