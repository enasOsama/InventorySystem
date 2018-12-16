using InventorySystem.Core.Entities;
using InventorySystem.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventorySystem.Controllers
{
    [Authorize]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProductsManager _productsManager;

        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        [HttpGet]
        public IHttpActionResult Get(int pageNo = 0, int pageSize = 10, string orderBy = "Model", string sortDirection = "Asc")
        {
            var result = _productsManager.GetProductsPagedFiltered(pageNo, pageSize, orderBy, sortDirection);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet]
        public IHttpActionResult GetProductsRequiringRestocking(int pageNo = 0, int pageSize = 10, string orderBy = "Model", string sortDirection = "Asc")
        {
            var result = _productsManager.GetProductsPagedFiltered(pageNo, pageSize, orderBy, sortDirection, p => p.AvailableQuantity <= p.MinimumQuantity);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        // Post: api/Products/5
        [HttpPost]
        public IHttpActionResult Post([FromBody] Product product)
        {
            var getProductResult = _productsManager.GetProductsFiltered(p => p.ID == product.ID);
            if (!getProductResult.Success)
                return BadRequest("Product not found");

            var insertResult = _productsManager.AddProduct(getProductResult.Data.FirstOrDefault());
            if (!insertResult.Success)
                return BadRequest(insertResult.Message);

            return Ok();
        }

        // Put: api/Products/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] Product product)
        {
            var getProductResult = _productsManager.GetProductsFiltered(p => p.ID == product.ID);
            if (!getProductResult.Success)
                return BadRequest("Product not found");

            var updateResult = _productsManager.EditProduct(getProductResult.Data.FirstOrDefault());
            if (!updateResult.Success)
                return BadRequest(updateResult.Message);

            return Ok();
        }


        // DELETE: api/Products/5
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var getProductResult = _productsManager.GetProductsFiltered(p => p.ID == id);
            if (!getProductResult.Success)
                return BadRequest("Product not found");

            var deleteResult = _productsManager.DeleteProduct(getProductResult.Data.FirstOrDefault());
            if (!deleteResult.Success)
                return BadRequest(deleteResult.Message);

            return Ok();
        }


        //// Post: api/Products/5
        //[HttpPost]
        //public IHttpActionResult AddProductItem([FromBody] ProductItem[] productItems)
        //{
        //    var getProductResult = _productsManager.GetProductsFiltered(p => p.ID == product.ID);
        //    if (!getProductResult.Success)
        //        return BadRequest("Product not found");

        //    var insertResult = _productsManager.AddProduct(getProductResult.Data.FirstOrDefault());
        //    if (!insertResult.Success)
        //        return BadRequest(insertResult.Message);

        //    return Ok();
        //}

    }
}
