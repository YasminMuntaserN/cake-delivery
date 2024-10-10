using CakeDeliveryDTO;
using CakeDeliveryDTO.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentData
    {
        /// <summary>
        /// Adds a new Payment to the database.
        /// </summary>
        /// <param name="payment">PaymentCreateDTO with payment data.</param>
        /// <returns>The new PaymentID if successful, otherwise null.</returns>
        public static int? Add(PaymentCreateDTO payment)
        {
            return DataAccessHelper.Add(
                "sp_AddPayment",  
                "NewPaymentID",   
                payment           
            );
        }

        /// <summary>
        /// Retrieves a payment by its ID.
        /// </summary>
        /// <param name="paymentId">The ID of the payment to find.</param>
        /// <returns>PaymentDTO if found, otherwise null.</returns>
        public static PaymentDTO? GetPaymentById(int? paymentId)
        {
            return DataAccessHelper.GetByParameter<PaymentDTO>(
                "sp_GetPaymentById",   // Stored procedure to get payment by ID
                "PaymentID",           // Parameter name for the payment ID
                paymentId,             // PaymentID to search for
                Mappings.MapPaymentDTOFromReader
            );
        }

      
        /// <summary>
        /// Retrieves a list of payments by the order ID.
        /// </summary>
        /// <param name="orderID">The order ID of the payments to find.</param>
        /// <returns>List of PaymentDTOs if found, otherwise an empty list.</returns>
        public static List<PaymentDTO> GetPaymentsByOrderId(int? orderID)
        {
            if (!orderID.HasValue || orderID <= 0)
            {
                return new List<PaymentDTO>(); // Return an empty list if orderID is not valid
            }

            return DataAccessHelper.GetAll<PaymentDTO>(
                "sp_GetPaymentsByOrderId",   // Stored procedure to get payments by order ID
                "OrderID",                   // Parameter name for order ID
                orderID,                     // OrderID to search for
                Mappings.MapPaymentDTOFromReader
            );
        }



        /// <summary>
        /// Updates an existing payment in the database.
        /// </summary>
        /// <param name="paymentToUpdate">PaymentUpdateDTO with updated payment data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdatePayment(PaymentDTO paymentToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdatePayment",   // Stored procedure for updating a payment
                paymentToUpdate       // DTO containing updated payment data
            );
        }

        /// <summary>
        /// Deletes a payment by its ID.
        /// </summary>
        /// <param name="paymentId">The ID of the payment to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeletePayment(int? paymentId)
        {
            return DataAccessHelper.Delete(
                "sp_DeletePayment",   // Stored procedure for deleting a payment
                "PaymentID",          // Parameter name for payment ID
                paymentId             // PaymentID to delete
            );
        }

        
        /// <summary>
        /// Retrieves all payments from the database.
        /// </summary>
        /// <returns>A list of PaymentDTO objects.</returns>
        public static List<PaymentDTO> GetAllPayments()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllPayments",  // Stored procedure to get all payments
                Mappings.MapPaymentDTOFromReader
            );
        }
    }

}
