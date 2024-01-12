using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class EventRepository
    {
        private readonly DataBaseContext _context;
        public EventRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<Event> GetAll()
        {
            return _context.Event.AsQueryable();
        }

        public IQueryable<Event> GetById(int id)
        {
            return _context.Event
                .AsQueryable()
                .Where(e => e.Id == id);
        }
    }
}
