import { formatCurrency } from "../../utils/helper";
import Quantity from "../cakes/Quantity";

function CartOverviewItem({item}) {
  const {cakeObject, quantity } = item;
  console.log(cakeObject);
  return (
    <li className={StyledContainer}>
      <img className={StyledImage} src={cakeObject.imageUrl} alt={cakeObject.cakeName}/>
        <div className={StyledSubContainer}>
          <p className={StyledQuantityContainer}>{quantity} x
          <span className="text-pink">{formatCurrency(cakeObject.price)}</span></p>
          <h4 className={styledHeader}>{cakeObject.cakeName}</h4>
          <Quantity cake={cakeObject}/>
      </div>
    </li>
  )
}

const StyledContainer = " flex gap-5  items-center mt-3 border-b border-gray-100 pb-3";
const StyledImage="w-16 h-16 object-cover align-middle rounded-full";
const StyledSubContainer = " flex gap-3 flex-col items-center";
const StyledQuantityContainer = " flex gap-20 items-center";
const styledHeader ="text-sm";



export default CartOverviewItem
