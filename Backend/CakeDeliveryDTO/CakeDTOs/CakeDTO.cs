using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeDeliveryDTO.CakeDTOs
{
    /// <summary>
    /// DTO for Updating or Find a cake.
    /// </summary>
    /// 
    public record CakeDTO(
        int? CakeID,
        string CakeName,
        string Description,
        decimal Price,
        int StockQuantity,
        string Category,
        string ImageUrl
    );

}
