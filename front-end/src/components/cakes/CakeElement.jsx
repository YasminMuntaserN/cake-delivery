import { HiMiniMinusCircle, HiMiniPlusCircle } from 'react-icons/hi2';
import Button from "../../ui/Button";

function CakeElement({ cake }) {
  return (
    <div className={StyledContainer}>
      <div className="w-[200px] h-[200px] mx-auto">
        <img 
          src={cake.image} 
          alt={cake.name} 
          className={StyledImage}
        />
      </div>
      <div className="mt-[100px] text-center">
        <p>{cake.name}</p>
      </div>
      <div>
        <span>{cake.price}</span>
        <Button>Add To Cart</Button>
      </div>
      <div className="flex justify-center space-x-2">
        <HiMiniMinusCircle className={StyledIcon} />
        <HiMiniPlusCircle className={StyledIcon} />
      </div>
    </div>
  );
}

export default CakeElement;

const StyledIcon='h-7 w-7 text-pink  hover:text-basic transition-colors duration-300';

const StyledImage="w-full h-48 sm:w-64 sm:h-64 object-cover rounded-lg shadow-lg mb-5 transition-transform duration-400 group-hover:scale-110" ;

const StyledContainer ="border border-red-200 text-center p-8 cursor-pointer h-full min-h-[19rem]";