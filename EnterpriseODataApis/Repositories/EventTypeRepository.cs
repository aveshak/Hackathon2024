using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class EventTypeRepository
    {
        private readonly DataBaseContext _context;
        public EventTypeRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<EventType> GetAll()
        {
            return _context.EventTypes.AsQueryable();
        }

        public IQueryable<EventType> GetById(int id)
        {
            return _context.EventTypes
                .AsQueryable()
                .Where(et => et.Id == id);
        }
    }
}
