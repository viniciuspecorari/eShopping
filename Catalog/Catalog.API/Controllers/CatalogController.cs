using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("GetProductByName/{name}")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByName(string name)
        {
            var query = new GetProductByNameQuery(name);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandsResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<BrandsResponse>>> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<TypesResponse>>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("GetProductByBrandName/{name}")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByBrandName(string name)
        {
            var query = new GetProductByBrandNameQuery(name);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var newProduct = await _mediator.Send(command);
            return Ok(newProduct);
        }

        [HttpPut("UpdateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var updatedProduct = await _mediator.Send(command);
            return Ok(updatedProduct);
        }

        [HttpDelete("DeleteProduct/{id}")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var command = new DeleteProductCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
