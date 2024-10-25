import { HiMiniPencil ,HiMiniPlusCircle } from "react-icons/hi2";
import Stats from "./Stats";

const Operations= [
  {
    icon :<HiMiniPencil className=" w-8 h-8" /> ,
    name: "Add Cake"
  },
  {
    icon :<HiMiniPlusCircle className="w-8 h-8"/> ,
    name: "Add Category"
  },
  {
    icon :<HiMiniPlusCircle className="w-8 h-8"/> ,
    name: "Add User"
  },
  {
    icon :<HiMiniPencil className="w-8 h-8 "/>,
    name:  "update User"
  },
];
function Stat() {
console.log(Operations);
  return (
    <div className={styledContainer}>
      {
        Operations.map((operation ,i)=><Stats key ={i+1 } operation={operation} color={i%2 == 0 ?"peach" :"pink"}/>)
      }
    </div>
  )
}
const styledContainer = "px-12 flex gap-3 items-center ";
export default Stat;
