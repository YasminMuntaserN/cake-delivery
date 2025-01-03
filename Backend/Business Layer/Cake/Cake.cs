﻿using CakeDeliveryDTO.CakeDTOs;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;

namespace Business_Layer.Cake
{
    public class Cake
    {
        public enum enFindBy
        {
            CakeID,
            CakeName
        };

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? CakeID { get; set; }
        public string CakeName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryID { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }  

        public Cake(CakeDTO cakeDto, enMode mode = enMode.AddNew)
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

        public CakeDTO ToCakeDto() =>
            new CakeDTO(CakeID, CakeName, Description, Price, StockQuantity, CategoryID, ImageUrl);


        private bool _Add()
        {
            CakeID = CakeData.Add(new CakeCreateDto(CakeName, Description, Price, StockQuantity, CategoryID, ImageUrl));
            return CakeID.HasValue;
        }




        private bool _Update()
        {
            return CakeData.UpdateCake(ToCakeDto());
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
            return CakeData.GetCakeById(cakeId);
        }


        public static CakeDTO? FindCakeByName(string cakeName)
        {
            return CakeData.GetCakeByName(cakeName);
        }


        public static bool Delete(int cakeID)
            => CakeData.DeleteCake(cakeID);


        public static CakeDTO Find<T>(T data, enFindBy findBy)
        {
            switch (findBy)
            {
                case enFindBy.CakeID:
                    if (data is int cakeId)
                    {
                        var cake = CakeData.GetCakeById(cakeId);
                        return cake ;
                    }
                    break;

                case enFindBy.CakeName:
                    if (data is string cakeName)
                    {
                        var cake = CakeData.GetCakeByName(cakeName);
                        return cake ;
                    }
                    break;
            }

            return null;
        }


        public static List<CakeDTO> All()
            => CakeData.GetAllCakes();

        public static List<CakeDTO> TopCakes()
            => CakeData.GetTopCakes();

        public static List<CakeDTO> AllByCategoryID(int categoryId) 
            => CakeData.GetCakesByCategory(categoryId);


        public static List<CakeDTO> AllByCategoryName(string categoryName)
            => CakeData.GetCakesByCategoryName(categoryName);

        public static List<CakeDTO> GetCakesByPage(int pageNumber, int pageSize)
            => CakeData.GetCakesByPage(pageNumber, pageSize);

        public static void GetTotalPagesAndRows(int catogeryId ,out int totalRows, out int totalPages)
            => CakeData.GetTotalPagesAndRows(catogeryId ,out totalRows, out totalPages);

        public static bool ChangeStockQuantiy(int? cakeId, int Quantity)
            => CakeData.ChangeStockQuantiy(cakeId, Quantity);
    }
}
