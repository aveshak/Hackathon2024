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
            return _context.EventStatus.AsQueryable();
        }

        public IQueryable<EventStatus> GetById(int id)
        {
            return _context.EventStatus
                .AsQueryable()
                .Where(es => es.Id == id);
        }
    }
}
