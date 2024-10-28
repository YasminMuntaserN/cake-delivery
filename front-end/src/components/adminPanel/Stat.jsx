import { HiMiniPencil ,HiMiniPlusCircle } from "react-icons/hi2";
import Stats from "./Stats";
import Modal from "../../ui/Modal";
import { useState } from "react";
import AddEditCakeForm from "../cakes/AddEditCakeForm";
import AddCategoryForm from "../Categories/AddEditCategoryForm";
import AddEditUserForm from "../user/AddEditUserForm";

const Operations= [
  {
    
    icon :<HiMiniPlusCircle className=" w-8 h-8 text-pink" /> ,
    name: "Add Cake"
  },
  {
    icon :<HiMiniPlusCircle className="w-8 h-8 text-p"/> ,
    name: "Add Category"
  },
  {
    icon :<HiMiniPlusCircle className="w-8 h-8 text-red-400"/> ,
    name: "Add User"
  },
];
function Stat() {
    const[Operation , setOperation]=useState("");
    console.log(`Operation: ${Operation}`);
  return (
    <Modal>
        <div className={styledContainer}>
          {
            Operations.map((operation ,i)=>
            <Modal.Open key ={i+1} onClick={()=>{setOperation(operation.name)}} >
                <button ><Stats operation={operation} color={i%2 == 0 ?"peach" :"pink"}/></button>
            </Modal.Open>
          )
          }
        </div>
        <Modal.Window>
          <div>
          { (Operation === "Add User"  )     &&<AddEditUserForm/>}
          { (Operation === "Add Cake" )      &&<AddEditCakeForm/>}
          { (Operation === "Add Category"  ) &&<AddCategoryForm/>}
          </div>
        </Modal.Window>
    </Modal>
  )
}
const styledContainer = "px-5 flex gap-20 items-center ";
export default Stat;
