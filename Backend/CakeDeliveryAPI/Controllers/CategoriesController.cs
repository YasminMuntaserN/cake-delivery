using Business_Layer.Category;
using CakeDeliveryDTO;
using CakeDeliveryDTO.CakeDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly CategoryValidator _validator = new CategoryValidator();

        // GET: api/categories/all
        [HttpGet("All", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CategoryDTO>> GetAllCategories()
            => GetAllEntities(() => Category.All());

        // GET: api/categories/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoryDTO> GetCategoryById(int id)
            => GetEntityByIdentifier(id, Category.FindCategoryById, category => Ok(category));

        // POST: api/categories
        [HttpPost(Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDTO>> AddCategory([FromForm] CategoryCreateDto newCategoryDTO, IFormFile photo)
        {
            if (newCategoryDTO == null || string.IsNullOrEmpty(newCategoryDTO.CategoryName))
            {
                return BadRequest("Invalid category data.");
            }

            var ImageUrl = await HelperClass.SaveImageAsync(photo,"categories");
            if (ImageUrl == null) return BadRequest("Failed to save the image.");

            Category categoryInstance = new Category(
                new CategoryDTO(null, newCategoryDTO.CategoryName, ImageUrl),
                Category.enMode.AddNew
            );

            var validationResult = _validator.Validate(categoryInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (categoryInstance.Save())
            {
                var locationUrl = Url.Link("GetCategoryById", new { id = categoryInstance.CategoryID });
                return Ok(locationUrl);
            }

            return BadRequest("Unable to create category.");
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromForm] CategoryDTO updatedCategory, IFormFile? photo = null)
        {
            if (id < 1 || updatedCategory == null || string.IsNullOrEmpty(updatedCategory.CategoryName))
            {
                return BadRequest("Invalid category data.");
            }

            CategoryDTO? existingCategory = Category.FindCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            Category categoryInstance;
            if (photo != null)
            {
                var ImageUrl = await HelperClass.SaveImageAsync(photo, "categories");
                if (ImageUrl == null) return BadRequest("Failed to save the image.");
                categoryInstance = new Category(new CategoryDTO(updatedCategory.CategoryID, updatedCategory.CategoryName, ImageUrl), Category.enMode.Update);
            }
            else
            {
                categoryInstance = new Category(updatedCategory, Category.enMode.Update);
            }

            var validationResult = _validator.Validate(categoryInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (categoryInstance.Save())
            {
                return Ok(categoryInstance.ToCategoryDto());
            }
            return StatusCode(500, new { message = "Error updating category." });
        }

     
        // DELETE: api/categories/{id}
        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCategory(int id)
            => DeleteEntity<Category>(id, Category.Delete, "Category");
    }
}
