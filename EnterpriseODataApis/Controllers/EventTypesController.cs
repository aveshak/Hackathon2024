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
    public class EventTypesController : ODataController
    {
        private readonly EventTypeRepository _repository;
        public EventTypesController(EventTypeRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<EventType>> Get()
        {
            IQueryable<EventType> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public ActionResult<EventType> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
