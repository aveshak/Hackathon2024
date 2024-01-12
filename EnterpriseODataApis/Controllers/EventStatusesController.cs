using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace EnterpriseODataApis.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [ODataRouteComponent("api/v2")]
    public class EventStatusesController : ODataController
    {
        private readonly EventStatusRepository _repository;
        public EventStatusesController(EventStatusRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<EventStatus>> Get()
        {
            IQueryable<EventStatus> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public ActionResult<EventStatus> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
