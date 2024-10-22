using Business_Layer.Cake;
using Business_Layer.Feedback;
using CakeDeliveryDTO.CakeDTOs;
using CakeDeliveryDTO.FeedbackDTOs;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/Feedbacks")]
    [ApiController]
    public class CustomerFeedbackController : BaseController
    {
        private readonly CustomerFeedbackValidator _validator = new CustomerFeedbackValidator();

        // GET: api/Feedback/all
        [HttpGet("AllFeedback", Name = "GetAllFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FeedbackDto>> GetAllCustomerFeedbacks()
            => GetAllEntities(() => CustomerFeedback.All());


        // GET: api/Feedback/all
        [HttpGet("All", Name = "AllFeedbacksWithCustomersName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FeedbackWithCustomerName>> GetAllFeedbacksWithCustomersName()
            => GetAllEntities(() => CustomerFeedback.AllFeedbacksWithCustomersName());


        // POST: api/feedback
        [HttpPost(Name = "AddFeedback")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FeedbackDto> AddFeedback([FromBody] FeedbackCreateDto newFeedbackDto)
        {
            if (newFeedbackDto == null || string.IsNullOrEmpty(newFeedbackDto.Feedback))
            {
                return BadRequest("Invalid feedback data.");
            }

            CustomerFeedback feedbackInstance = new CustomerFeedback(
                new FeedbackDto(null, newFeedbackDto.CustomerID, newFeedbackDto.Feedback, DateTime.Now , newFeedbackDto.Rating),
                CustomerFeedback.enMode.AddNew
            );

            var validationResult = _validator.Validate(feedbackInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (feedbackInstance.Save())
            {
                return CreatedAtRoute("GetFeedbackById", new { id = feedbackInstance.FeedbackID }, newFeedbackDto);
            }

            return BadRequest("Unable to create feedback.");
        }


        // PUT: api/feedback/{id}
        [HttpPut("{id}", Name = "UpdateFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FeedbackDto> UpdateFeedback(int id, FeedbackDto updatedFeedback)
        {
            if (id < 1 || updatedFeedback == null || string.IsNullOrEmpty(updatedFeedback.Feedback))
            {
                return BadRequest("Invalid feedback data.");
            }

            FeedbackDto? existingFeedback = CustomerFeedback.FindById(id);
            if (existingFeedback == null)
            {
                return NotFound($"Feedback with ID {id} not found.");
            }

            CustomerFeedback feedbackInstance = new CustomerFeedback(updatedFeedback, CustomerFeedback.enMode.Update);

            var validationResult = _validator.Validate(feedbackInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (feedbackInstance.Save())
            {
                return Ok(feedbackInstance.ToFeedbackDto());
            }

            return StatusCode(500, new { message = "Error updating feedback." });
        }


        // DELETE: api/feedback/{id}
        [HttpDelete("{id}", Name = "DeleteFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteFeedback(int id)
            => DeleteEntity<CustomerFeedback>(id, CustomerFeedback.Delete, "Feedback");
    }
}
