using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoriesController(ICategoryRepository repository)
        {
                this._repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            await _repository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult>GetAllCategory()
        {
           var categoryes= await _repository.GetAllCategoryAsync();
            var responce = new List<CategoryDto>();
            foreach (var category in categoryes)
            {
                responce.Add(new CategoryDto{
                    Id = category.Id,
                    Name=category.Name,
                    UrlHandle=category.UrlHandle
                });
            }

            return Ok(responce);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult>GetCategoryById([FromRoute] Guid id)
        {
            var category = await _repository.GetCategoryByIdAsync(id);  
            return Ok(category);
        }
    }
}
