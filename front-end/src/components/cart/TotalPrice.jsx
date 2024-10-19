import { useSelector } from "react-redux";
import Button from "../../ui/Button";
import { getTotalPrice } from "./cartSlice";
import { formatCurrency } from "../../utils/helper";

function TotalPrice() {
    const totalPrice= useSelector(getTotalPrice);
    return (
        <div className={styledContainer }>
            <p>Subtotal: 
            <span className="text-pink "> {formatCurrency(totalPrice)}</span>
            </p>
            <div className={styledBtnContainer }>
            <Button>Order it now</Button>
                <Button>Continue Shopping</Button>
            </div>
        </div>
    );
}
const styledContainer = "mt-10 ml-20";
const styledBtnContainer = " flex flex-wrap gap-10";

export default TotalPrice;