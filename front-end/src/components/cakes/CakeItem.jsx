import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import Button from "../../ui/Button";
import { formatCurrency } from '../../utils/helper';
// import { useDispatch } from "react-redux"
// import { addItem } from '../cart/cartSlice';
function CakeItem({ cake }) {
  // const dispatch =useDispatch();
  return (
    <>
    <div className="w-[200px] h-[200px] mx-auto">
      <img 
        src={cake.imageUrl} 
        alt={cake.cakeName} 
        className={StyledImage}
      />
    </div>
    <div className="mt-[100px] text-center text-basic">
      <p>{cake.cakeName}</p>
    </div>
    <div>
      <span className='mr-12 text-pink'>{formatCurrency(cake.price)}</span>
      <div>
        {/* <Button onClick={()=>dispatch(addItem(cake))}>Add To Cart</Button> */}
        <Button>Add To Cart</Button>

      </div>
    </div>
    {false && (
      <div className={StyledSubContainer}>
        <HiMiniMinusCircle className={StyledIcon} />
        <p>0</p>
        <HiMiniPlusCircle className={StyledIcon} />
      </div>
    )}
  </>
  )
}
const StyledIcon = 'h-7 w-7 text-pink hover:text-basic transition-colors duration-300';
const StyledImage = 'w-full h-48 sm:w-64 sm:h-64 object-cover rounded-lg shadow-lg mb-5 transition-transform duration-400 group-hover:scale-110';
const StyledSubContainer = 'flex justify-center space-x-12';
export default CakeItem
