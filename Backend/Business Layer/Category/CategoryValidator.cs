using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Category
{
    public class CategoryValidator : BaseValidator<Category>
    {
        public override ValidationResult Validate(Category category)
        {
            if (!HasValidCategoryID(category.CategoryID))
                AddError("CategoryID is invalid.");

            if (!HasValidCategoryName(category.CategoryName))
                AddError("CategoryName is required.");

            if (!HasValidCategoryImageUrl(category.CategoryImageUrl))
                AddError("CategoryImageUrl is invalid or empty.");

            return Result;
        }

        private bool HasValidCategoryID(int? categoryID) => !categoryID.HasValue || categoryID > 0;

        private bool HasValidCategoryName(string categoryName) => !string.IsNullOrWhiteSpace(categoryName);

        private bool HasValidCategoryImageUrl(string categoryImageUrl) => !string.IsNullOrWhiteSpace(categoryImageUrl);
    }
}
