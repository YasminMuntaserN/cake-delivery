import { useState } from "react";
import Modal from "../../../ui/Modal"
import {HiMiniPencilSquare, HiCalculator ,HiArrowsPointingOut} from "react-icons/hi2";
import Quantity from "../../cakes/Quantity";
import Sizes from "../../cakes/Sizes";
import AddEditCakeForm from "../../cakes/AddEditCakeForm";
import AddEditCategoryForm from "../../Categories/AddEditCategoryForm";

function Edit({cake , isUpdating =false , category}) {
    const [changeQuantity , setChangeQuantity] =useState(false);
    const [changeSize , setChangeSize] =useState(false);

  return (
    <Modal>
    <div>
        <Modal.Open>
          <button><HiMiniPencilSquare /></button>
        </Modal.Open>
      </div>
      <Modal.Window>
      { Boolean(cake) ?
        ( !isUpdating ?
              <div className={StyledContainer}>
                <div className={StyledOptionsContainer}>
                <button className={StyledOption} onClick={() => setChangeQuantity(!changeQuantity)}>
                  <HiCalculator className={StyledIcon}/>
                  <span className="text-xl"> Quantity</span>
                </button>
                <button className={StyledOption} onClick={() => setChangeSize(!changeSize)}>
                  <HiArrowsPointingOut className={StyledIcon}/>
                  <span className="text-xl"> Size</span>
                </button>
                </div>
                {changeQuantity && <Quantity cake={cake} />}
                {changeSize && <Sizes cake={cake} />}
              </div>
              :
              <AddEditCakeForm cake={cake}/>
      ) :
          <AddEditCategoryForm category={category} />
      }   
      </Modal.Window>
    </Modal>
  )
}
const StyledOptionsContainer="flex flex-row";
const StyledContainer="text-center";
const StyledOption ="flex justify-content-between border-2 border-gray-100 mb-2 rounded-md pointer m-5 p-5 hover:bg-peach";
const StyledIcon ="text-pink mx-3 h-8 w-8 ";
export default Edit
