import { useContext, useEffect, useState } from "react";
import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import { useCartItems } from "../../context/CartItemsContext";

function Quantity({ cake ,OnIsAdded}) {
  const {handleDelete ,handleInc, handleDec, cart } = useCartItems();
  const [quantity, setQuantity] = useState(1);

  useEffect(() => {
    const item = cart.find(item => item.cakeObject.cakeID === cake.cakeID);
    if (item) {
      const { quantity } = item;
      setQuantity(quantity);

      if (!(quantity >= 1)){
          OnIsAdded();
          handleDelete(cake.cakeID);
      }
    }
  }, [cart, cake.cakeID]);
  console.log(quantity);
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
