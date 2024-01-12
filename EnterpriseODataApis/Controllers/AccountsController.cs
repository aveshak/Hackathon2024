using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace EnterpriseODataApis.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ODataRouteComponent("api/v1")]
    public class AccountsController : ODataController
    {
        private readonly AccountRepository _repository;
        public AccountsController(AccountRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            IQueryable<Account> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public ActionResult<Account> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
