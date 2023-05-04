using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSW2.Models;
using ProjectSW2.Repository;

namespace ProjectSW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var Products = await unitOfWork.Products.GetAllAsync();
            return Ok(Products);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Product product = unitOfWork.Products.GetById(id);
            if(id == 0 || product==null)
                return NotFound("this product not found");

            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product Productcreated)
        {
            if (Productcreated == null)
            {
                return BadRequest();
            }
            Product product = unitOfWork.Products.Find(x => x.Name.Trim().ToUpper() == Productcreated.Name.Trim().ToUpper());
            if (product != null)
            {
                return BadRequest("Name already exist");
            }
            await unitOfWork.Products.AddAsync(Productcreated);
            unitOfWork.Complete();
            return Ok(Productcreated);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            Product Product = await unitOfWork.Products.GetByIdAsync(id);
            if (Product == null)
                return NotFound("Not found this Product");
            unitOfWork.Products.Update(Product);
            unitOfWork.Complete();
            return Ok(Product);


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product Product = await unitOfWork.Products.GetByIdAsync(id);
            if (Product == null)
                return NotFound("This cateogry Not found");
            unitOfWork.Products.Delete(Product);
            unitOfWork.Complete();
            return Ok(Product);
        }
















    }
}
