import { HiTrash } from "react-icons/hi2";
import { formatCurrency } from "../../utils/helper";
import Loader from "../common/Loader";
import Error from "../common/Error";
import { useCake } from "../../hooks/useCake";

function CartItem({ OrderItem }) {
    const {cakeID, quantity, pricePerItem } = OrderItem;
    const {cake , isLoading, error}=useCake(cakeID);

    if (isLoading) return <Loader />;
    if (error) return <Error />;

    return (
        <div className={styledRow }>
            <img className={styledImage}  src={cake.imageUrl} alt={cake.cakeName} />
            <p>{cake.cakeName}</p>
            <p>{quantity}</p>
            <p>{formatCurrency(pricePerItem)}</p>
            <div>
                <button><HiTrash /></button>
            </div>
        </div>
    );
}
const styledRow = "grid grid-cols-[1.8fr_2.0fr_1.2fr_0.5fr_1fr] gap-[2.4rem] items-center p-[1.4rem] px-[2.4rem] py-[2.0rem] border-b border-b-[var(--color-grey-100)]";
const styledImage = "ml-[20px] block w-[6.4rem] aspect-[3/2] object-cover object-cover transform scale-[150%] translate-x-[-7px]";
export default CartItem;