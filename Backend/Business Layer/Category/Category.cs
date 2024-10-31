using CakeDeliveryDTO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Category
{
    public class Category
    {
        // Enum to define different operations to find categories
        public enum enFindBy
        {
            CategoryID,
            CategoryName
        };

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }

        public Category(CategoryDTO categoryDto, enMode mode = enMode.AddNew)
        {
            CategoryID = categoryDto.CategoryID;
            CategoryName = categoryDto.CategoryName;
            CategoryImageUrl = categoryDto.CategoryImageUrl;

            Mode = mode;
        }

        public CategoryDTO ToCategoryDto() =>
            new CategoryDTO(CategoryID, CategoryName, CategoryImageUrl);

        private bool _Add()
        {
            CategoryID = CategoryData.Add(new CategoryCreateDto(CategoryName, CategoryImageUrl));
            return CategoryID.HasValue;
        }

        private bool _Update()
        {
            return CategoryData.UpdateCategory(ToCategoryDto());
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static CategoryDTO? FindCategoryById(int categoryId)
        {
            return CategoryData.GetCategoryById(categoryId);
        }

        public static string GetCategoryNameById(int categoryId)
        {
            return CategoryData.GetCategoryNameById(categoryId);
        }

        public static CategoryDTO? FindCategoryByName(string categoryName)
        {
            return CategoryData.GetCategoryByName(categoryName);
        }

        public static bool Delete(int categoryId)
            => CategoryData.DeleteCategory(categoryId);


        public static List<CategoryDTO> All()
            => CategoryData.GetAllCategories();

}
}
