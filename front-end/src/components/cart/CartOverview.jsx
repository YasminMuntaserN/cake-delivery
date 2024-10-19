import Modal from "../../ui/Modal"
import CartOverviewItem from "./CartOverviewItem";
import { useSelector } from "react-redux";
import { getCart } from "./cartSlice";

function CartOverview() {
  const cart = useSelector(getCart);
  
  return (
    <Modal >
    <Modal.Open>
    <div className={StyledContainer}>
        <i className="cursor-pointer">
            <img className="w-[40px]" src="./cart.png" alt="Cart" />
        </i>
        <span className={StyledItemCount}>0</span>
      </div>
      </Modal.Open>
      <Modal.Window type="List">
          <ul className ={StyledList}>
          {
            // cart.length ===0 ?<p>There is no items  </p> :
            cart.map((item)=><CartOverviewItem item={item} key={item.cakeObject.cakeID}/>)
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
