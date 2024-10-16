using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeDeliveryDTO.FeedbackDTOs
{
    /// <summary>
    /// DTO for Updating or Find a FeedbackID.
    /// </summary>
    /// 
    public record FeedbackDto(
        int? FeedbackID,
        int CustomerID,
        string Feedback,
        DateTime FeedbackDate
    );

}
