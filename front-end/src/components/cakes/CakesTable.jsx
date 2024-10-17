import CakeElement from "./CakeElement";

import Loader from "../common/Loader";
import Error from "../common/Error";
import { useCakes } from "./cakeHooks/useCakes";
import { getCart } from "../cart/cartSlice";
import { useSelector } from "react-redux";


function CakesTable() {
    const cart = useSelector(getCart);
    console.log(cart);

    const {cakes ,error , isLoading}=useCakes();
    if (isLoading) return <Loader />;
    if (error) return <Error />;

    return (
        <div className={styledContainer}>
            {cakes.map((cake) => (
                <CakeElement key={cake.cakeID} cake={cake} />
            ))}
        </div>
    );
}
const styledContainer = "mt-10 flex justify-center flex-wrap gap-10 relative";

export default CakesTable

