import CakeElement from "./CakeElement";
import { useParams } from "react-router-dom";
import Loader from "../common/Loader";
import Error from "../common/Error";
import { useCakes } from "./hooks/useCakes";

function CakesTable() {
    const { categoryId } = useParams(); 
    const {cakes ,error , isLoading}=useCakes({categoryId});
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

