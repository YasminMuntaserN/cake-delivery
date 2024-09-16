using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTOs
{
    public class CakeDTO
    {
        public CakeDTO(int? cakeId, string cakeName, string description, decimal price, int? stockQuantity, string category, string imageUrl, DateTime createdAt)
        {
            this.CakeID = cakeId;
            this.CakeName = cakeName;
            this.Description = description;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.CreatedAt = createdAt;
        }

        public int? CakeID { get; set; }
        public string CakeName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? StockQuantity { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
