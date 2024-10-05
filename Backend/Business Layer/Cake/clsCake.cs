using CakeDeliveryDTO.CakeDTOs;
using DataAccessLayer;

namespace Business_Layer.Cake
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
        public int CategoryID { get; set; }
        public string ImageUrl { get; set; }

        public clsCake(CakeDTO cakeDto, enMode mode = enMode.AddNew)
        {
            CakeID = cakeDto.CakeID;
            CakeName = cakeDto.CakeName;
            Description = cakeDto.Description;
            Price = cakeDto.Price;
            StockQuantity = cakeDto.StockQuantity;
            CategoryID = cakeDto.CategoryID;
            ImageUrl = cakeDto.ImageUrl;

            Mode = mode;
        }

        // Convert to DTO
        public CakeDTO ToCakeDto() =>
            new CakeDTO(CakeID, CakeName, Description, Price, StockQuantity, CategoryID, ImageUrl);

        private bool _Add()
        {
            CakeID = clsCakeData.Add(new CakeCreateDto(CakeName, Description, Price, StockQuantity, CategoryID, ImageUrl));
            return CakeID.HasValue;
        }


        private bool _Update()
        {
            return clsCakeData.UpdateCake(ToCakeDto());
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


        public static CakeDTO? FindCakeById(int cakeId)
        {
            return clsCakeData.GetCakeById(cakeId);
        }


        public static CakeDTO? FindCakeByName(string cakeName)
        {
            return clsCakeData.GetCakeByName(cakeName);
        }


        public static bool Delete(int cakeID)
            => clsCakeData.DeleteCake(cakeID);


        public static CakeDTO Find<T>(T data, enFindBy findBy)
        {
            switch (findBy)
            {
                case enFindBy.CakeID:
                    if (data is int cakeId)
                    {
                        var cake = clsCakeData.GetCakeById(cakeId);
                        return cake ;
                    }
                    break;

                case enFindBy.CakeName:
                    if (data is string cakeName)
                    {
                        var cake = clsCakeData.GetCakeByName(cakeName);
                        return cake ;
                    }
                    break;
            }

            return null;
        }


        public static List<CakeDTO> All()
            => clsCakeData.GetAllCakes();


        public static List<CakeDTO> AllByCategoryID(int categoryId) // New method to get cakes by CategoryID
            => clsCakeData.GetCakesByCategory(categoryId);


        public static List<CakeDTO> AllByCategoryName(string categoryName)
            => clsCakeData.GetCakesByCategoryName(categoryName);
    }
}
