namespace DTOs
{
    public class PaymentDTO
    {
        public PaymentDTO(int? paymentId, int? orderId, string paymentMethod, DateTime paymentDate, decimal amountPaid, string paymentStatus)
        {
            this.PaymentID = paymentId;
            this.OrderID = orderId;
            this.PaymentMethod = paymentMethod;
            this.PaymentDate = paymentDate;
            this.AmountPaid = amountPaid;
            this.PaymentStatus = paymentStatus;
        }

        public int? PaymentID { get; set; }
        public int? OrderID { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
    }

}
