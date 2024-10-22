using CakeDeliveryDTO.FeedbackDTOs;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Feedback
{
    public class CustomerFeedback
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? FeedbackID { get; set; }
        public int CustomerID { get; set; }
        public string Feedback { get; set; }
        public DateTime FeedbackDate { get; set; }
        public int Rating { get; set; }

        public CustomerFeedback(FeedbackDto feedbackDto, enMode mode = enMode.AddNew)
        {
            FeedbackID = feedbackDto.FeedbackID;
            CustomerID = feedbackDto.CustomerID;
            Feedback = feedbackDto.Feedback;
            FeedbackDate = feedbackDto.FeedbackDate;
            Rating= feedbackDto.Rating;
            Mode = mode;
        }


        public FeedbackDto ToFeedbackDto() =>
            new FeedbackDto(FeedbackID, CustomerID, Feedback, FeedbackDate, Rating);

        public static FeedbackDto FindById(int feedbackId)
              => FeedbackData.FindFeedbackById(feedbackId);

        private bool _Add()
        {
            FeedbackID = FeedbackData.Add(new FeedbackCreateDto(CustomerID, Feedback, FeedbackDate, Rating));
            return FeedbackID.HasValue;
        }

        private bool _Update()
        {
            return FeedbackData.UpdateFeedback(ToFeedbackDto());
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }


        public static bool Delete(int feedbackId)
            => FeedbackData.DeleteFeedback(feedbackId);

        public static List<FeedbackDto> All()
            => FeedbackData.GetAllFeedbacks();

        public static List<FeedbackWithCustomerName> AllFeedbacksWithCustomersName()
            => FeedbackData.GetAllFeedbacksWithCustomersName();

    }
}

