import { useQuery } from "@tanstack/react-query";
//import { getOrderItems } from "../../services/apiCart";
import CartItem from "./CartItem";
//import Loader from "../common/Loader";
//import Error from "../common/Error";
import { getCart } from "../cart/cartSlice";
import { useSelector } from "react-redux";

function CartTable() {
/* const { data: OrderItems = [], error, isLoading } = useQuery(
        {
            queryKey: ["orderItems"],
            queryFn: getOrderItems
        }

    );
    console.log(OrderItems);


    if (isLoading) return <Loader />;
    if (error) return <Error />;*/

    const cart = useSelector(getCart);
    console.log(cart);

    return (
        <div role="table" className={styledTable}>

            <header role="row" className={styledTableHeader}>
                <div></div>
                <div>Image</div>
                <div>Cake Name</div>
                <div>Quantity</div>
                <div>Price </div>
                <div>Delete</div>
                <div></div>
            </header>
            {cart.map((Item) => (
                <CartItem Item={Item}  key={Item.cakeObject.cakeID} />
            ))}
        </div>
    );
}
const styledTable = "lg:mx-[60px] sm:mx-[30px] mt-20 border border-grey-200 text-[1.1rem] bg-grey-0 rounded-[7px] overflow-hidden"

const styledTableHeader = " grid grid-cols-[0.2fr_1.8fr_2.0fr_1.2fr_0.5fr_1fr_0.2fr] gap-[3.4rem] items-center bg-grey-50 border-b border-grey-100  uppercase tracking-[0.4px]  text-grey-600 p-[10px_10px]"

export default CartTable;
