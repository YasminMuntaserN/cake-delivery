using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDeliveryDTO
{
    /// <summary>
    /// DTO for sending Email.
    /// </summary>
    /// 
    public record EmailRequestDto(
        string Recipient,
        string Subject,
        string Body
        );
}
