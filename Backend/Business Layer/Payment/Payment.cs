using CakeDeliveryDTO.PaymentDTOs;
using CakeDeliveryDTO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Payment
{
    public class Payment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? PaymentID { get; set; }
        public int? OrderID { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }

        public Payment(PaymentDTO paymentDto, enMode mode = enMode.AddNew)
        {
            PaymentID = paymentDto.PaymentID;
            OrderID = paymentDto.OrderID;
            PaymentMethod = paymentDto.PaymentMethod;
            PaymentDate = paymentDto.PaymentDate;
            AmountPaid = paymentDto.AmountPaid;
            PaymentStatus = paymentDto.PaymentStatus;

            Mode = mode;
        }

        public PaymentDTO ToPaymentDto() =>
            new PaymentDTO(PaymentID, OrderID, PaymentMethod, PaymentDate, AmountPaid, PaymentStatus);

     
        private bool _Add()
        {
            PaymentID = PaymentData.Add(new PaymentCreateDTO(OrderID, PaymentMethod,  AmountPaid, PaymentStatus));
            return PaymentID.HasValue;
        }

 
        private bool _Update()
        {
            return PaymentData.UpdatePayment(ToPaymentDto());
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

        public static PaymentDTO? FindPaymentById(int paymentId)
        {
            return PaymentData.GetPaymentById(paymentId);
        }

        public static List<PaymentDTO> FindPaymentByOrderId(int orderId)
        {
            return PaymentData.GetPaymentsByOrderId(orderId);
        }

        public static bool Delete(int paymentId)
            => PaymentData.DeletePayment(paymentId);


        public static List<PaymentDTO> All()
            => PaymentData.GetAllPayments();

    }

}
