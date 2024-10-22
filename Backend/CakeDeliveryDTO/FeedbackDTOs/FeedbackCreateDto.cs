using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CakeDeliveryDTO.FeedbackDTOs
{
    /// <summary>
    /// DTO for creating a new Feedback.
    /// </summary>
    /// 
    public record FeedbackCreateDto(
        int CustomerID,
        string Feedback,
        DateTime FeedbackDate,
        int Rating
    );

}
