import { useSelector } from "react-redux";
import { formatCurrency } from "../../utils/helper";
import { getTotalPrice } from "../cart/cartSlice";
import Button from "../../ui/Button";
import { useOrder } from "./hooks/useOrder";
import { getCustomerId } from "../customer/customerSlice";

function Order() {
  const totalPrice =useSelector(getTotalPrice);
  const date =new Date();
  const customerId =useSelector(getCustomerId);
  const  { isAdding, addOrder ,id } =useOrder();

  function handleOrder(){
    const orderData ={
                        customerID: customerId,
                        totalAmount: totalPrice,
                        paymentStatus: "Completed",
                        deliveryStatus: "Delivered"
                      }
                      console.log(orderData);
    addOrder(JSON.stringify(orderData));
      console.log(id);
  }

  return (
    <div className={StyledContainer}>
      <h3 className={StyledHeader}>Order Details :</h3>
      <p className={StyledText}>Order Date :
          <span className={StyledValue}>{date.toUTCString()}</span></p>
      <p className={StyledText}>Total Amount :
        <span className={StyledValue}> {formatCurrency(totalPrice)}</span></p>

      <select className={StyledSelect}>
        <option> 💳 Credit Card </option>
        <option> 💸 Bank Transfer </option>
        <option> 🏧 PayPal  </option>
      </select> 
      <div className={StyledSubContainer}>
        <img className={StyledImg} src="girl-cake-delivery.png" alt="girl-cake-delivery"/>
        <div>
        <p className={StyledDeliveryTime}>Your order will arrived after <span className={StyledValue}>1 hour </span></p>
        <Button type="submit" onClick={()=>handleOrder()}>Order it Now </Button>
        </div>
      </div>
    </div>
  )
}
const StyledContainer = "ws-1/2  mx-7 m-10  border-2  rounded-lg p-12 ";
const StyledText ="mt-7 bg-gray-100 p-3 rounded-lg ";
const StyledValue ="text-sm text-pink";
const StyledHeader ="text-2xl text-basic";
const StyledImg="w-1/2 h-full";
const StyledSubContainer="flex";
const StyledDeliveryTime =" text-xl mt-20 text-basic";
const StyledSelect ="border-none outline-none mt-7 bg-gray-100 p-4 rounded-lg w-full";




export default Order
