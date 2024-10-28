import { useEffect, useState } from "react";
import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import { useCartItems } from "../../context/CartItemsContext";

function Quantity({ cake, onIsAdded = null }) {
  const { handleDelete, handleInc, handleDec, cart } = useCartItems();
  const [quantity, setQuantity] = useState(1);

  useEffect(() => {
    const item = cart.find(item => item.cakeObject.cakeID === cake.cakeID);
    if (item) {
      const { quantity } = item;
      setQuantity(quantity);
      if (typeof onIsAdded === 'function') {
        onIsAdded(true); 
      }
      if (quantity < 1) {
        handleDelete(cake.cakeID);
        if (typeof onIsAdded === 'function') {
          onIsAdded(false); 
        }
      }
    }
  }, [cart, cake.cakeID, handleDelete, onIsAdded]);

  const handleIncrement = () => {
    handleInc(cake.cakeID);
    setQuantity(prevQuantity => prevQuantity + 1);
    if (typeof onIsAdded === 'function') {
      onIsAdded(true);
    }
  };

  const handleDecrement = () => {
    if (quantity > 1) {
      handleDec(cake.cakeID);
      setQuantity(prevQuantity => prevQuantity - 1);
    } else {
      handleDelete(cake.cakeID);
      if (typeof onIsAdded === 'function') {
        onIsAdded(false); 
      }
    }
  };

  return (
    <div className={StyledSubContainer}>
      <HiMiniMinusCircle className={StyledIcon} onClick={handleDecrement} />
      <p>{quantity}</p>
      <HiMiniPlusCircle className={StyledIcon} onClick={handleIncrement} />
    </div>
  );
}

const StyledIcon = 'h-10 w-10 text-pink hover:text-basic transition-colors duration-300';
const StyledSubContainer = 'flex justify-center space-x-12 mt-5';

export default Quantity;
