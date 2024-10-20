import { useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import {getCakes, getCakesByCategory } from "../../../services/apiCakes";

export function useCakes() {
const { categoryId } = useParams(); 

const { data: cakes = [], error, isLoading } = useQuery(
    Number(categoryId) === -1
        ? {
            queryKey: ["cakes"],
            queryFn: getCakes,
        }
        : {
            queryKey: ['cakes', categoryId], 
            queryFn: () => getCakesByCategory(categoryId), 
        }
);

return {cakes ,error , isLoading};
}
