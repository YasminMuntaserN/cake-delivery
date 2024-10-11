using CakeDeliveryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryData
    {
        /// <summary>
        /// Adds a new Category to the database.
        /// </summary>
        /// <param name="category">CategoryCreateDto with Category data.</param>
        /// <returns>The new CategoryID if successful, otherwise null.</returns>
        public static int? Add(CategoryCreateDto category)
        {
            return DataAccessHelper.Add(
                "sp_AddCategory",
                "NewCategoryID",
                category
            );
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to find.</param>
        /// <returns>CategoryDTO if found, otherwise null.</returns>
        public static CategoryDTO? GetCategoryById(int? categoryId)
        {
            return DataAccessHelper.GetByParameter<CategoryDTO>(
                "sp_GetCategoryById",
                "CategoryID",
                categoryId,
                Mappings.MapCategoryDTOFromReader
            );
        }

        /// <summary>
        /// Retrieves a category by its name.
        /// </summary>
        /// <param name="categoryName">The name of the category to find.</param>
        /// <returns>CategoryDTO if found, otherwise null.</returns>
        public static CategoryDTO? GetCategoryByName(string categoryName)
        {
            return DataAccessHelper.GetByParameter<CategoryDTO>(
                "sp_GetCategoryByName",
                "CategoryName",
                categoryName,
                Mappings.MapCategoryDTOFromReader
            );
        }

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="categoryToUpdate">CategoryDTO with updated category data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateCategory(CategoryDTO categoryToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateCategory",
                categoryToUpdate
            );
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeleteCategory(int? categoryId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteCategory",
                "CategoryID",
                categoryId
            );
        }

        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>A list of CategoryDTO objects.</returns>
        public static List<CategoryDTO> GetAllCategories()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllCategory",
                Mappings.MapCategoryDTOFromReader
            );
        }
    }

}
