import Button from "../../ui/Button";
import { formatCurrency } from '../../utils/helper';
import { useState } from 'react';
import { useCartItems } from '../../context/CartItemsContext';
import Sizes from './Sizes';
import Quantity from './Quantity';
import Image from "../../ui/Image";
import toast from "react-hot-toast";

function CakeItem({ cake }) {
  const { handleAdd } = useCartItems();
  const [isAdded, setIsAdded] = useState(false);

  const handleAddToCart = () => {
    if(cake.stockQuantity === 0){
      toast.error("This cake is currently out of stock and cannot be purchased 🥲");
    }else{
    handleAdd(cake);
    setIsAdded(true);
    }
  };

  return (
    <>
      <div className={StyledContainer}>
        <Image src={cake.imageUrl} alt={cake.cakeName} className={StyledImage}  entity="cakes" />
      </div>
      <div className={StyledName}>
        <p>{cake.cakeName}</p>
      </div>
      <div>
        <span className={StylePrice}>{formatCurrency(cake.price)}</span>
        {!isAdded ? (
          <div>
            <Button onClick={handleAddToCart}>Add To Cart</Button>
          </div>
        ) : (
          <div>
            <Quantity cake={cake} onIsAdded={setIsAdded} />
            <Sizes cake={cake} />
          </div>
        )}
      </div>
    </>
  );
}

const StyledContainer = "w-[200px] h-[200px] mx-auto";
const StyledImage = 'w-full h-48 sm:w-64 sm:h-64 object-cover rounded-lg shadow-lg mb-5 transition-transform duration-400 group-hover:scale-110';
const StyledName = "mt-[100px] mb-5 text-center text-basic";
const StylePrice = 'mr-0 text-pink';

export default CakeItem;

