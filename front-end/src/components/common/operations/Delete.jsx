import Button from "../../../ui/Button";
import Modal from "../../../ui/Modal";
import { HiTrash } from "react-icons/hi2";
import { useCartItems } from "../../../context/CartItemsContext";
import { useCakeOperations } from "../../../context/CakeContext";
import { useDeleteCategory } from "../../Categories/hook/useDeleteCategory";
import { useDeleteUser } from "../../user/hooks/useDeleteUser";


function Delete({id ,isDeleting =false ,entity}) {
  const {handleDelete} =useCartItems();
  const {handleDeleteCake}=useCakeOperations();
  const {deleteCategoryObject}=useDeleteCategory();
  const {deleteUserObject}=useDeleteUser();
  const handleCakeDelete =()=>{
    if(isDeleting){
      handleDeleteCake(id);// in this we will remove item from cart 
    }else{
      handleDelete(id);// in this we will remove item from cake table in admin panel 
    }
  }

  const handleCategoryDelete =()=>{
    deleteCategoryObject(id);// in this we will remove item from category table in admin panel 
  }

  const handleUserDelete =()=>{
    deleteUserObject(id);// in this we will remove item from user table in admin panel
  }

  const deleteOperation =()=> entity === "Cake" ?handleCakeDelete() : entity === "Category"?handleCategoryDelete():handleUserDelete();

  return (
    <Modal>
      <Modal.Open>
          <button><HiTrash /></button>
      </Modal.Open>
      <Modal.Window>
        <div className={StyledMessageContainer}>
            <h4 className="text-2xl text-pink mb-5">Delete item</h4>
            <p>Are You sure that you want to delete this item ?? This action cannot be undone.</p>
            <Button type="Delete" onClick={()=>deleteOperation()}>Delete</Button>
            <Button type="Cancel">Cancel</Button>
        </div>
      </Modal.Window>
    </Modal>
  )
}
const StyledMessageContainer ='w-[300px] h-[200px]'
export default Delete