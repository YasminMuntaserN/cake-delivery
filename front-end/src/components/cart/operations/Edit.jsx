// import { useState } from "react";
import Modal from "../../../ui/Modal"
import {HiMiniPencilSquare, HiCalculator ,HiArrowsPointingOut} from "react-icons/hi2";

function Edit() {
    // const [changeQuantity , setChangeQuantity] =useState(false);
    // const [changeSize , setChangeSize] =useState(false);


  return (
    <Modal>
    <div>
        <Modal.Open>
          <button><HiMiniPencilSquare /></button>
        </Modal.Open>
      </div>
      <Modal.Window>
      <div className={StyledOptionsContainer}>
            <button className={StyledOption} ><HiCalculator className="text-pink text-3Xl m-2 mt-0"/><span className="text-sm "> Quantity</span> </button>
            <button  className={StyledOption}><HiArrowsPointingOut className="text-pink text-3Xl m-2 mt-0 "/> <span className="text-sm "> Size</span> </button>
        </div>
      </Modal.Window>
    </Modal>
  )
}
// const StyledOptionsContainer=" absolute bg-[#cbd5e1] top-[-30px] right-[-30px] py-3 px-3 w-30 rounded-md z-9000";
const StyledOptionsContainer=" ";

const StyledOption ="flex justify-content-between border-b border-gray-100 mb-2 pointer";

export default Edit
