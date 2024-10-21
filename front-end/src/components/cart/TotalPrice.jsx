import { useSelector } from "react-redux";
import Button from "../../ui/Button";
import { getTotalPrice } from "./cartSlice";
import { formatCurrency } from "../../utils/helper";
import { useNavigate } from "react-router-dom";
import toast from "react-hot-toast";

function TotalPrice() {
    const totalPrice= useSelector(getTotalPrice);
    const navigation =useNavigate();
    return (
        <div className={styledContainer }>
            <p className={styledText}>Subtotal: 
            <span className="text-pink "> {formatCurrency(totalPrice)}</span>
            </p>
            <div className={styledBtnContainer }>
            <Button onClick={()=>navigation("/cakes/-1")}> now Continue Shopping </Button>
            <Button onClick={()=>{
                if(totalPrice > 0)
                navigation("/checkout")
                else
                toast.error("there is no item in your cart , you cant complete this operation 🥲 ")
            }}>Order it</Button>
            </div>
        </div>
    );
}
const styledContainer = " my-10 ml-20 flex flex-row gap-10 text-center";
const styledBtnContainer = " mt-[-30px] flex flex-wrap gap-10";
const styledText = "text-2xl";


export default TotalPrice;