using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;

namespace EnterpriseODataApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ODataController
    {
        private readonly ProductRepository _repository;
        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Product>> Get()
        {
            IQueryable<Product> result = _repository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        public ActionResult<Product> Get([FromRoute] int key)
        {
            return Ok(_repository.GetById(key));
        }
    }
}
