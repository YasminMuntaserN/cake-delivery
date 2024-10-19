import { useSelector } from "react-redux";
import Button from "../../ui/Button";
import { getTotalPrice } from "./cartSlice";
import { formatCurrency } from "../../utils/helper";
import { useNavigate } from "react-router-dom";

function TotalPrice() {
    const totalPrice= useSelector(getTotalPrice);
    const navigation =useNavigate();
    return (
        <div className={styledContainer }>
            <p>Subtotal: 
            <span className="text-pink "> {formatCurrency(totalPrice)}</span>
            </p>
            <div className={styledBtnContainer }>
            <Button onClick={()=>navigation("/cakes/-1")}> now Continue Shopping </Button>
            <Button onClick={()=>navigation("/checkout")}>Order it</Button>
            </div>
        </div>
    );
}
const styledContainer = "mt-10 ml-20";
const styledBtnContainer = " flex flex-wrap gap-10";

export default TotalPrice;