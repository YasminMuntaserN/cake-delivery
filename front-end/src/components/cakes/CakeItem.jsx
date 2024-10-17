import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import Button from "../../ui/Button";
import { formatCurrency } from '../../utils/helper';
import { useDispatch } from "react-redux";
import { addItem, setQuantity as SetNewQuantity ,deleteItem } from '../cart/cartSlice';
import { useState } from 'react';

function CakeItem({ cake }) {
  const [isAdded, setIsAdded] = useState(false);
  const [quantity, setQuantity] = useState(1);
  
  const dispatch = useDispatch();

  const handleAdd =(cake)=>{
      dispatch(addItem(cake)); 
      setIsAdded(true);
      setQuantity(1); 
  }

  const handleInc = (id) => {
    setQuantity((prevQuantity) => prevQuantity + 1);
    dispatch(SetNewQuantity({id ,quantity}));
  }

  const handleDec = (id) => {
    if(quantity >0){
      setQuantity((prevQuantity) => prevQuantity - 1);
      dispatch(SetNewQuantity({id ,quantity}));
  }else{
    setQuantity(0);
    dispatch(deleteItem(id));
    setIsAdded(false);
  }
}

  return (
    <>
      <div className={StyledContainer}>
        <img src={cake.imageUrl} alt={cake.cakeName} className={StyledImage} />
      </div>
      <div className={StyledName}>
        <p>{cake.cakeName}</p>
      </div>
      <div>
        <span className={StylePrice}>{formatCurrency(cake.price)}</span>
        {!isAdded &&
          <div>
          <Button onClick={() => handleAdd(cake)}>
            Add To Cart
          </Button>
        </div>
        }
      </div>
      {isAdded && (
        <div className={StyledSubContainer}>
          <HiMiniMinusCircle className={StyledIcon} onClick={() => handleDec(cake.cakeID)} />
          <p>{quantity}</p>
          <HiMiniPlusCircle className={StyledIcon} onClick={() => handleInc(cake.cakeID)} />
        </div>
      )}
    </>
  );
}

const StyledContainer = "w-[200px] h-[200px] mx-auto";
const StyledIcon = 'h-10 w-10 text-pink hover:text-basic transition-colors duration-300';
const StyledImage = 'w-full h-48 sm:w-64 sm:h-64 object-cover rounded-lg shadow-lg mb-5 transition-transform duration-400 group-hover:scale-110';
const StyledSubContainer = 'flex justify-center space-x-12 mt-5';
const StyledName = "mt-[100px] mb-5 text-center text-basic";
const StylePrice = 'mr-0 text-pink';

export default CakeItem;
