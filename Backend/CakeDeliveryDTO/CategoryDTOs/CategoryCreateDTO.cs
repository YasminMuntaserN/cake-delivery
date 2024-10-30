using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeDeliveryDTO;

/// <summary>
/// DTO for Updating or Find a Category.
/// </summary>
/// 
public record CategoryCreateDto(
    string CategoryName,
    string? CategoryImageURL = null
);
