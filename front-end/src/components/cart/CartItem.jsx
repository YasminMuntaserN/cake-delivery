import Image from "../../ui/Image";
import { formatCurrency } from "../../utils/helper";
import Delete from "../common/operations/Delete";
import Edit from "../common/operations/Edit";


function CartItem({ item }) {
    const {cakeObject, quantity, sizeId } = item;
    const size= sizeId===1 ?"Small" : sizeId==   2 ?"medium":"large";
    return (
        <div className={styledRow }>
            <p></p>
            <Image src={cakeObject.imageUrl} alt={cakeObject.cakeName} className={styledImage} entity="cakes"/>
            <p>{cakeObject.cakeName}</p>
            <p>{quantity}</p>
            <p className="text-pink">{formatCurrency(cakeObject.price)}</p>
            <p>{size}</p>
            <Delete id={cakeObject.cakeID} isDeleting ={false} entity="Cake"/>
            <Edit cake={cakeObject}/>
        </div>
    );
}
const styledRow = "grid grid-cols-[0.1fr_2fr_2fr_0.7fr_0.7fr_0.7fr_0.7fr_1fr] gap-[2.4rem] items-center p-[1.4rem] px-[2.4rem] py-[2.0rem] border-b border-gray-100";
const styledImage = "ml-[20px] block w-[6.4rem] aspect-[3/2] object-cover object-cover transform scale-[150%] translate-x-[-7px]";
export default CartItem;