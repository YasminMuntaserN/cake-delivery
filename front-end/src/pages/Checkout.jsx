import { useEffect, useState } from "react";
import Map from "../ui/Map"
import { useSelector } from "react-redux";
import { getCustomer, getCustomerId } from "../components/customer/customerSlice";
import Order from "../components/order/Order";
import AddCustomerForm from "../components/customer/AddCustomerForm";

function Checkout() {
  const [coordinates, setCoordinates] = useState([]);

  const customerId =useSelector(getCustomerId);

  const handleGeocode = (position) => {
    setCoordinates(position);
  };
  console.log(`customerId: ${customerId}`);
  return (
    <>
      <h2 className={StyledHeader}> Please Fill Out Your Information</h2>
      <div className="flex ">
          <AddCustomerForm onGeocode={handleGeocode} />
          { !customerId ? 
          <Map coordinates={coordinates}/> :<Order />}
      </div>
    </>
  )
}
const StyledHeader =" mx-12 my-7 text-2xl text-basic";


export default Checkout
