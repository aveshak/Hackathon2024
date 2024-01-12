using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;

namespace EnterpriseODataApis.Repositories
{
    public class EventStatusRepository
    {
        private readonly DataBaseContext _context;
        public EventStatusRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<EventStatus> GetAll()
        {
            return _context.EventStatuses.AsQueryable();
        }

        public IQueryable<EventStatus> GetById(int id)
        {
            return _context.EventStatuses
                .AsQueryable()
                .Where(es => es.Id == id);
        }
    }
}
