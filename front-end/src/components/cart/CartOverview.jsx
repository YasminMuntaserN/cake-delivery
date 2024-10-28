import Modal from "../../ui/Modal"
import { useSelector } from "react-redux";
import { getCart } from "./cartSlice";
import Empty from "../../ui/Empty";
import CartOverviewItem from "../cart/CartOverviewItem";

function CartOverview() {
  const cart = useSelector(getCart);
  
  return (
    <Modal >
    <Modal.Open>
    <div className={StyledContainer}>
        <i className="cursor-pointer">
            <img className="w-[40px]" src="./cart.png" alt="Cart" />
        </i>
        <span className={StyledItemCount}>{cart.length}</span>
      </div>
      </Modal.Open>
      <Modal.Window type="List">
          <ul className ={StyledList}>
          {
            cart.length > 0 ?
            cart.map((item)=><CartOverviewItem item={item} key={item.cakeObject.cakeID}/>)
            :<Empty resourceName="items in the cart" />
          }
        </ul>
      </Modal.Window>
    </Modal>
  )
}
const StyledContainer ="relative";
const StyledList ="  h-screen mt-[-30px] w-full bg-white pt-5 pl-5";
const StyledItemCount="absolute top-[-5px] right-[-5px] bg-pink text-white w-[20px] h-[20px] rounded-full text-[0.8rem] font-medium flex items-center justify-center";
export default CartOverview
