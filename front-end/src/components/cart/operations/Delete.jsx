import { useContext } from "react";
import Button from "../../../ui/Button";
import Modal from "../../../ui/Modal";
import { HiTrash } from "react-icons/hi2";
import { useCartItems } from "../../../context/CartItemsContext";
import { useDeleteCake } from "../../cakes/cakeHooks/useDeleteCake";

function Delete({id  , isDeleting =false}) {
  const {handleDelete} =useCartItems();
  const {deleteCakeObject} =useDeleteCake();
  const handleClickedDelete =()=>{
    if(isDeleting){
      console.log("we will delele it  :(");
      deleteCakeObject(id) 
    }else{
      console.log("worng way");
      handleDelete(id)
    }
  }
  return (
    <Modal>
      <Modal.Open>
          <button><HiTrash /></button>
      </Modal.Open>
      <Modal.Window>
        <div className={StyledMessageContainer}>
            <h4 className="text-2xl text-pink mb-5">Delete item</h4>
            <p>Are You sure that you want to delete this item ?? This action cannot be undone.</p>
            <Button type="Delete" onClick={()=>handleClickedDelete()}>Delete</Button>
            <Button type="Cancel">Cancel</Button>
        </div>
      </Modal.Window>
    </Modal>
  )
}
const StyledMessageContainer ='w-[300px] h-[200px]'
export default Delete
//()=>{isDeleting ?deleteCakeObject(id) :  handleDelete(id)}