import { useContext, useEffect, useState } from "react";
import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import { useCartItems } from "../../context/CartItemsContext";

function Quantity({ cake }) {
  const {handleInc, handleDec, cart } = useCartItems();
  const [quantity , setQuantity]=useState(0);

  useEffect(()=>{
    const item =cart.find(item => item.cakeObject.cakeID === cake.cakeID);
      if(item){
      const {quantity}=item;
        setQuantity(quantity);
      }
  },[cart ,cake.cakeID]);
  return (
      <div className={StyledSubContainer}>
        <HiMiniMinusCircle className={StyledIcon} onClick={() => handleDec(cake.cakeID)} />
        <p>{quantity}</p> 
        <HiMiniPlusCircle className={StyledIcon} onClick={() => handleInc(cake.cakeID)} />
      </div>
  )
}
const StyledIcon = 'h-10 w-10 text-pink hover:text-basic transition-colors duration-300';
const StyledSubContainer = 'flex justify-center space-x-12 mt-5';

export default Quantity
