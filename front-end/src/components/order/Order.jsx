import { useSelector } from "react-redux";
import { formatCurrency } from "../../utils/helper";
import { getTotalPrice } from "../cart/cartSlice";
import Button from "../../ui/Button";
import { useOrder } from "./hooks/useOrder";
import { usePayment } from "../payment/hooks/usePayment";
import {useState } from "react";
import PaymentOptions from "../payment/PaymentOptions";
import AddCustomerFeedback from "../customerFeedback/AddCustomerFeedback";
import { useCartItems } from "../../context/CartItemsContext";
import useOrderItem from "./hooks/useOrderItems";
import { getCustomerId } from "../customer/customerSlice";
import { useStockQuantity } from "../cakes/hooks/useStockQuantity";

function Order() {
  const [paymentMethod, setPaymentMethod] = useState("Credit Card");
  const customerId = useSelector(getCustomerId);
  const totalPrice = useSelector(getTotalPrice);
  const { addPayment, id: paymentId } = usePayment();
  const { addOrder } = useOrder();
  const {newOrderItem}=useOrderItem();
  const {updateCakeStockQuantity}=useStockQuantity();
  const{cart}=useCartItems();
  const date = new Date();


  function handleOrder() {
    const orderData = {
      customerID: customerId,
      totalAmount: totalPrice,
      paymentStatus: "Completed",
      deliveryStatus: "Delivered"
    };
    addOrder(orderData, {
      onSuccess: (newOrderId) => {
        if (newOrderId) {
          const PaymentData = {
            orderID: newOrderId,
            paymentMethod,
            amountPaid: totalPrice,
            paymentStatus: "Completed"
          };
          addPayment(PaymentData,{
            onSuccess: () => {
              let orderItemData = { };
              cart.map((item)=>{
                orderItemData ={
                orderID: newOrderId,
                cakeID: item.cakeObject.cakeID,
                sizeID: item.sizeId,
                quantity: item.quantity,
                pricePerItem: item.cakeObject.price
              };
              newOrderItem(orderItemData);
              if((item.cakeObject.stockQuantity - item.quantity ) < 0){
              updateCakeStockQuantity({cakeID :item.cakeObject.cakeID ,stockQuantiy : item.cakeObject.stockQuantity})
              }else{
              updateCakeStockQuantity({cakeID :item.cakeObject.cakeID ,stockQuantiy : item.quantity})
              }
            }
          )}
          });
        }
      }
    });
  }



  return (
    <div className={StyledContainer}>
      <h3 className={StyledHeader}>Order Details :</h3>
      <p className={StyledText}>
        Order Date : <span className={StyledValue}>{date.toUTCString()}</span>
      </p>
      <p className={StyledText}>
        Total Amount :
        <span className={StyledValue}>{formatCurrency(totalPrice)}</span>
      </p>
      <PaymentOptions handlePaymentMethod={setPaymentMethod} />

      <div className={StyledSubContainer}>
        <img
          className={StyledImg}
          src="girl-cake-delivery.png"
          alt="girl-cake-delivery"
        />
        {!paymentId ? (
          <div>
            <p className={StyledDeliveryTime}>
              Your order will arrive after{" "}
              <span className={StyledValue}>1 hour </span>
            </p>
            <Button type="submit" onClick={() => handleOrder()}>
              Order it Now
            </Button>
          </div>
        ) : (
          <AddCustomerFeedback />
        )}
      </div>
    </div>
  );
}

const StyledContainer = "ws-1/2 mx-7 m-10 border-2 rounded-lg p-12";
const StyledText = "mt-7 bg-gray-100 p-3 rounded-lg";
const StyledValue = "text-sm text-pink";
const StyledHeader = "text-2xl text-basic";
const StyledImg = "w-full h-full";
const StyledSubContainer = "grid lg:grid-cols-[1fr_1.2fr]";
const StyledDeliveryTime = "text-xl mt-20 text-basic";

export default Order;
