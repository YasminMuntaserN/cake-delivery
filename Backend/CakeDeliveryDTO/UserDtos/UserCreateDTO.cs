using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDeliveryDTO.UserDtos
{
    /// <summary>
    /// DTO for creating a user.
    /// </summary>s
    /// 
    public record UserCreateDTO(
        string Email,
        string Password
    );
}
