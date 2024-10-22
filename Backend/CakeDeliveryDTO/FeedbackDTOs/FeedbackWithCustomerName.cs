using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDeliveryDTO.FeedbackDTOs
{
    /// <summary>
    /// DTO for  get Feedbacks with customer name.
    /// </summary>
    /// 
    public record FeedbackWithCustomerName(
        int? FeedbackID,
        string CustomerName,
        string Feedback,
        DateTime FeedbackDate,
        int Rating
    );
}
