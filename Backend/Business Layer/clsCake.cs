using CakeDeliveryDTO.CakeDTOs;
using DataAccessLayer;

namespace Business_Layer
{
    public class clsCake
    {
        // Enum to define different operations to find cakes
        public enum enFindBy
        {
            CakeID,
            CakeName
        };

        // Enum for modes (Add or Update)
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? CakeID { get; set; }
        public string CakeName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public clsCake(CakeDTO cakeDto, enMode mode = enMode.AddNew)
        {
            CakeID = cakeDto.CakeID;
            CakeName = cakeDto.CakeName;
            Description = cakeDto.Description;
            Price = cakeDto.Price;
            StockQuantity = cakeDto.StockQuantity;
            Category = cakeDto.Category;
            ImageUrl = cakeDto.ImageUrl;

            Mode = mode;
        }

        // Convert to DTO
        public CakeDTO ToCakeDto() =>
            new CakeDTO(this.CakeID, this.CakeName, this.Description, this.Price, this.StockQuantity, this.Category, this.ImageUrl);


        private bool _Add()
        {
            CakeID = clsCakeData.Add(new CakeCreateDto(this.CakeName, this.Description, this.Price, this.StockQuantity, this.Category, this.ImageUrl));
            return (CakeID.HasValue);
        }

        private bool _Update()
        {
            return clsCakeData.Update(this.ToCakeDto());
        }

        public bool Save()
        {
            if (!_Validate())
            {
                return false;
            }

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

        public bool TryToSave(out bool isValidationError)
        {
            if (!_Validate())
            {
                isValidationError = true;
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        isValidationError = false;
                        return true;
                    }
                    else
                    {
                        isValidationError = false;
                        return false;
                    }

                case enMode.Update:
                    isValidationError = false;
                    return _Update();
            }

            isValidationError = false;
            return false;
        }

        public static clsCake? FindBy<T>(T data, enFindBy findBy)
        {
            var finder = CakeFinderFactory.GetFinder(findBy);
            return finder.FindCake(data);
        }

        public static bool Delete(int? cakeID)
            => clsCakeData.Delete(cakeID);

        public static bool Exists(object data, enFindBy findBy)
        {
            var verifier = ExistenceVerifierFactory.GetExistenceVerifier(findBy);
            return verifier != null && verifier.Exists(data);
        }

        public static List<CakeViewDto> All()
            => clsCakeData.AllCakes();

        public static int Count()
            => clsCakeData.Count();
    }

}
