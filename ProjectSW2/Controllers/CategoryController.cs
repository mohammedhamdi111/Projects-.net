using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSW2.Models;
using ProjectSW2.Repository;

namespace ProjectSW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {  
            var Categories = await unitOfWork.Categories.GetAllAsync();
            return Ok(Categories);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var category = unitOfWork.Categories.GetById(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory( Category categorycreated)
        {
            if (categorycreated == null)
            {
                return BadRequest();
            }
            var categroy = unitOfWork.Categories.Find(x => x.Name.Trim().ToUpper() == categorycreated.Name.Trim().ToUpper());
            if (categroy != null)
            {
                return BadRequest("Name already exist");
            }
            await unitOfWork.Categories.AddAsync(categorycreated);
            unitOfWork.Complete();
            return Ok(categorycreated);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            Category category= await unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                return NotFound("Not found this Category");
            unitOfWork.Categories.Update(category);
            unitOfWork.Complete();
            return Ok(category);


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var category =await unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                return NotFound("This cateogry Not found");
            unitOfWork.Categories.Delete(category);
            unitOfWork.Complete();
            return Ok(category);
        }










    }
}
