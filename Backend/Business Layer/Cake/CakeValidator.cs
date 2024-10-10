using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Business_Layer.Cake
{
    public class CakeValidator : BaseValidator<Cake>
    {
        public override ValidationResult Validate(Cake cake)
        {
            if (!HasValidCakeID(cake.CakeID))
                AddError("CakeID is invalid.");

            if (!HasValidCakeName(cake.CakeName))
                AddError("CakeName is required.");


            if (!HasValidPrice(cake.Price))
                AddError("Price must be greater than zero.");

            if (!HasValidStockQuantity(cake.StockQuantity))
                AddError("StockQuantity cannot be negative.");

            if (!HasValidCategoryID(cake.CategoryID))
                AddError("CategoryID must be a positive integer.");

            return Result;
        }

        private bool HasValidCakeID(int? cakeID) => !cakeID.HasValue || cakeID > 0;

        private bool HasValidCakeName(string cakeName) => !string.IsNullOrWhiteSpace(cakeName);

        private bool HasValidPrice(decimal price) => price > 0;

        private bool HasValidStockQuantity(int stockQuantity) => stockQuantity >= 0;

        private bool HasValidCategoryID(int categoryID) => categoryID > 0;

    }

}
