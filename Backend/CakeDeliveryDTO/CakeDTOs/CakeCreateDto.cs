using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeDeliveryDTO.CakeDTOs
{
    /// <summary>
    /// DTO for creating a new cake.
    /// </summary>
    /// 
    public record CakeCreateDto(
        string CakeName,
        string Description,
        decimal Price,
        int StockQuantity,
        int CategoryID,
        string? ImageUrl  = null
        );
}
