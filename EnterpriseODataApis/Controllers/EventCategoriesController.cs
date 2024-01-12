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
    public class EventCategoriesController : ODataController
    {
        private readonly EventCategoryRepository _repository;
        public EventCategoriesController(EventCategoryRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<EventCategory>> Get()
        {
            IQueryable<EventCategory> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public ActionResult<EventCategory> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
