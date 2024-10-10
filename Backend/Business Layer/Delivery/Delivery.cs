using CakeDeliveryDTO.DeliveryDTO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Delivery
{
    public class Delivery
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? DeliveryID { get; set; }
        public int OrderID { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string DeliveryCountry { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }

        public Delivery(DeliveryDTO deliveryDto, enMode mode = enMode.AddNew)
        {
            DeliveryID = deliveryDto.DeliveryID;
            OrderID = deliveryDto.OrderID;
            DeliveryAddress = deliveryDto.DeliveryAddress;
            DeliveryCity = deliveryDto.DeliveryCity;
            DeliveryPostalCode = deliveryDto.DeliveryPostalCode;
            DeliveryCountry = deliveryDto.DeliveryCountry;
            DeliveryDate = deliveryDto.DeliveryDate;
            DeliveryStatus = deliveryDto.DeliveryStatus;

            Mode = mode;
        }

        // Convert to DTO
        public DeliveryDTO ToDeliveryDto() =>
            new DeliveryDTO(DeliveryID, OrderID, DeliveryAddress, DeliveryCity, DeliveryPostalCode, DeliveryCountry, DeliveryDate, DeliveryStatus);

        private bool _Add()
        {
            DeliveryID = DeliveryData.Add(new DeliveryCreateDTO(OrderID, DeliveryAddress, DeliveryCity, DeliveryPostalCode, DeliveryCountry, DeliveryDate, DeliveryStatus));
            return DeliveryID.HasValue;
        }

        private bool _Update()
        {
            return DeliveryData.UpdateDelivery(ToDeliveryDto());
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

        
        public static DeliveryDTO? FindDeliveryById(int deliveryId)
        {
            return DeliveryData.GetDeliveryById(deliveryId);
        }


        public static bool Delete(int deliveryId)
            => DeliveryData.DeleteDelivery(deliveryId);


        public static List<DeliveryDTO> All()
            => DeliveryData.GetAllDeliveries();

    }

}
