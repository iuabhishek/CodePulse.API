
using CodePulse.API.Models.DTO;
using CodePulse.Application.Features.Categories.Command;
using CodePulse.Application.Features.Categories.Queries;
using CodePulse.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ISender _sender;
        public CategoriesController(ISender sender)
        {

            _sender = sender;
        }     

        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromBody] CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            category= await _sender.Send(new CreateCategoryCommand(category));
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _sender.Send(new GetAllCategoryQuery());
            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> CategoryById([FromRoute] Guid id)
        {
            var category = await _sender.Send(new GetCategoryByIdQuery(id));
            if (category is null)
            {
                return NotFound();
            }
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryDto request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            category = await _sender.Send(new UpdateCategoryCommand(id, category));
            if (category is null)
            {
                return NotFound();
            }
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var deletedCategory = await _sender.Send(new DeleteCategoryCommand(id));
            if (deletedCategory is null)
            {
                return NotFound();
            }
            var response = new DeleteCategoryDto
            {
                Id = deletedCategory.Id,
                Name = deletedCategory.Name,
                UrlHandle = deletedCategory.UrlHandle
            };

            return Ok(response);

        }

    }
}
