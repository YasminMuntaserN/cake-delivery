import Button from "../../ui/Button";
import { formatCurrency } from '../../utils/helper';
import { useState } from 'react';
import { useCartItems } from '../../context/CartItemsContext';
import Sizes from './Sizes';
import Quantity from './Quantity';

function CakeItem({ cake }) {
  const { handleAdd } = useCartItems();
  const [isAdded, setIsAdded] = useState(false);

  const handleAddToCart = () => {
    handleAdd(cake);
    setIsAdded(true);
  };

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

