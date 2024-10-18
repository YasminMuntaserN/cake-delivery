import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import Button from "../../ui/Button";
import { formatCurrency } from '../../utils/helper';
import { useContext, useEffect, useState } from 'react';
import Sizes from './Sizes';
import { CartItemsContext } from '../../context/CartItemsContext';

function CakeItem({ cake }) {
  const { handleAdd, handleInc, handleDec, handleSize, cart } = useContext(CartItemsContext);

  const [isAdded , setIsAdded]=useState(false);
  const [quantity , setQuantity]=useState(0);

useEffect(()=>{
  const item =cart.find(item => item.cakeObject.cakeID === cake.cakeID);
    if(item){
    const {quantity}=item;
      setQuantity(quantity);
    }
},[cart ,cake.cakeID]);
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
        {!isAdded && ( 
          <div>
            <Button onClick={() =>{ 
              setIsAdded((added)=>!added) ;
              handleAdd(cake)}}>
              Add To Cart
            </Button>
          </div>
        )}
      </div>
      {isAdded && ( 
        <div>
          <div className={StyledSubContainer}>
            <HiMiniMinusCircle className={StyledIcon} onClick={() => handleDec(cake.cakeID)} />
            <p>{quantity}</p> 
            <HiMiniPlusCircle className={StyledIcon} onClick={() => handleInc(cake.cakeID)} />
          </div>
          <Sizes handleSetSize={(sizeId) => handleSize(cake.cakeID, sizeId)} />
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
