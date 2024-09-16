namespace DTOs
{
    public class DeliveryDTO
    {
        public DeliveryDTO(int deliveryId, int orderId, string deliveryAddress, string deliveryCity, string deliveryPostalCode, string deliveryCountry, DateTime deliveryDate, string deliveryStatus)
        {
            this.DeliveryID = deliveryId;
            this.OrderID = orderId;
            this.DeliveryAddress = deliveryAddress;
            this.DeliveryCity = deliveryCity;
            this.DeliveryPostalCode = deliveryPostalCode;
            this.DeliveryCountry = deliveryCountry;
            this.DeliveryDate = deliveryDate;
            this.DeliveryStatus = deliveryStatus;
        }

        public int DeliveryID { get; set; }
        public int OrderID { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string DeliveryCountry { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }
    }

}
