import CartItem from "./CartItem";
import { getCart } from "../cart/cartSlice";
import { useSelector } from "react-redux";

function CartTable() {
    const cart = useSelector(getCart);
    return (
        <div role="table" className={styledTable}>

            <header role="row" className={styledTableHeader}>
                <div></div>
                <div>Image</div>
                <div>Cake Name</div>
                <div>Quantity</div>
                <div>Price </div>
                <div>Size </div>
                <div>Delete</div>
                <div>Edit</div>
                <div></div>
            </header>
            {cart.map((Item) => (
                <CartItem Item={Item}  key={Item.cakeObject.cakeID} />
            ))}
        </div>
    );
}
const styledTable = "lg:mx-[60px] sm:mx-[30px] mt-20 border border-grey-200 text-[1.1rem] bg-grey-0 rounded-[7px] overflow-hidden"

const styledTableHeader = " grid grid-cols-[0.4fr_1.8fr_1.8fr_0.7fr_0.7fr_0.7fr_0.7fr_0.7fr_0.2fr] gap-[3.4rem] items-center bg-grey-50 border-b order-grey-100  uppercase tracking-[0.4px]  text-grey-600 p-[10px_10px]"

export default CartTable;
