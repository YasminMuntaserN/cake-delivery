using CakeDeliveryDTO.FeedbackDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FeedbackData
    {
        /// <summary>
        /// Adds a new Feedback to the database.
        /// </summary>
        /// <param name="Feedback">FeedbackCreateDto with Feedback data.</param>
        /// <returns>The new FeedbackID if successful, otherwise null.</returns>
        public static int? Add(FeedbackCreateDto feedback)
        {
            return DataAccessHelper.Add(
                "sp_Addfeedback",
                "NewfeedbackID",
                feedback
            );
        }

      
        /// <summary>
        /// Updates an existing Feedback in the database.
        /// </summary>
        /// <param name="FeedbackToUpdate">FeedbackDTO with updated Feedback data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateFeedback(FeedbackDto FeedbackToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateFeedback",
                FeedbackToUpdate
            );
        }

        /// <summary>
        /// find Feedback by id.
        /// </summary>
        /// <param name="FeedbackToFind">FeedbackDTO with find Feedback data.</param>
        /// <returns>.</returns>
        public static FeedbackDto  FindFeedbackById(int? FeedbackId)
        {
            return DataAccessHelper.GetByParameter(
                "sp_FindFeedbackById",
                "FeedbackId",
                FeedbackId,
                Mappings.MapFeedbackDTOFromReader
                );
        }


        /// <summary>
        /// Deletes a Feedback by its ID.
        /// </summary>
        /// <param name="FeedbackId">The ID of the Feedback to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeleteFeedback(int? FeedbackId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteFeedback",
                "FeedbackID",
                FeedbackId
            );
        }


        /// <summary>
        /// Retrieves all Feedbacks from the database.
        /// </summary>
        /// <returns>A list of FeedbackDTO objects.</returns>
        public static List<FeedbackDto> GetAllFeedbacks()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllFeedbacks",
                Mappings.MapFeedbackDTOFromReader
            );
        }

        /// <summary>
        /// Retrieves all Feedbacks from the database.With Customers Name
        /// </summary>
        /// <returns>A list of FeedbackDTO objects.</returns>
        public static List<FeedbackDto> GetAllFeedbacksWithCustomersName()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllFeedbacks",
                Mappings.MapFeedbackDTOFromReader
            );
        }
    }
}
