using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace EnterpriseODataApis.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ODataRouteComponent("api/v1")]
    public class EventsController : ODataController
    {
        private readonly EventRepository _repository;
        public EventsController(EventRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            IQueryable<Event> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public ActionResult<Event> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
