using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDeliveryDTO.UserDtos
{
    /// <summary>
    /// DTO for Updating or Find a user.
    /// </summary>
    /// 
    public record UserDTO(
        int? UserID,
        string Email,
        string Password
    );
}
