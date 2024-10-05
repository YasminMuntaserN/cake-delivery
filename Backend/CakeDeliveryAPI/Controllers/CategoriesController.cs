using Business_Layer.Category;
using CakeDeliveryDTO;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly clsCategoryValidator _validator = new clsCategoryValidator();

        // GET: api/categories/all
        [HttpGet("All", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CategoryDTO>> GetAllCategories()
            => GetAllEntities(() => clsCategory.All());

        // GET: api/categories/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoryDTO> GetCategoryById(int id)
            => GetEntityByIdentifier(id, clsCategory.FindCategoryById, category => Ok(category));

        // POST: api/categories
        [HttpPost(Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CategoryDTO> AddCategory([FromBody] CategoryCreateDto newCategoryDTO)
        {
            if (newCategoryDTO == null || string.IsNullOrEmpty(newCategoryDTO.CategoryName))
            {
                return BadRequest("Invalid category data.");
            }

            clsCategory categoryInstance = new clsCategory(
                new CategoryDTO(null, newCategoryDTO.CategoryName,  newCategoryDTO.CategoryImageURL),
                clsCategory.enMode.AddNew
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
                return CreatedAtRoute("GetCategoryById", new { id = categoryInstance.CategoryID }, newCategoryDTO);
            }

            return BadRequest("Unable to create category.");
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoryDTO> UpdateCategory(int id, CategoryDTO updatedCategory)
        {
            if (id < 1 || updatedCategory == null || string.IsNullOrEmpty(updatedCategory.CategoryName))
            {
                return BadRequest("Invalid category data.");
            }

            CategoryDTO? existingCategory = clsCategory.FindCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            clsCategory categoryInstance = new clsCategory(updatedCategory, clsCategory.enMode.Update);

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
            => DeleteEntity<clsCategory>(id, clsCategory.Delete, "Category");
    }
}
