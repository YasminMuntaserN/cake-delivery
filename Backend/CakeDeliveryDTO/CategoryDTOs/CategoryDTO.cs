using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeDeliveryDTO;

/// <summary>
/// DTO for Create a new Category.
/// </summary>
/// 
public record CategoryDTO(
    int? CategoryID,
    string CategoryName,
    string? CategoryImageUrl = null
);
