import { useQuery } from "@tanstack/react-query";
import CakeElement from "./CakeElement";
import {getCakes, getCakesByCategory } from "../../services/apiCakes";
import { useParams } from "react-router-dom";
import Loader from "../common/Loader";
import Error from "../common/Error";


function CakesTable() {
    const { categoryId } = useParams(); // Get categoryId from URL

    const { data: cakes = [], error, isLoading } = useQuery(
        Number(categoryId) === -1
            ? {
                queryKey: ["cakes"],
                queryFn: getCakes,
            }
            : {
                queryKey: ['cakes', categoryId], // Unique key including categoryId
                queryFn: () => getCakesByCategory(categoryId), // Fetch function
            }
    );


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
const styledContainer = "mt-10 flex justify-center flex-wrap gap-10";

export default CakesTable

