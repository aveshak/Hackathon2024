using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace EnterpriseODataApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ODataController
    {
        private readonly CompanyRepository _repository;
        public CompaniesController(CompanyRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Company>> Get()
        {
            IQueryable<Company> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        public ActionResult<Company> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
