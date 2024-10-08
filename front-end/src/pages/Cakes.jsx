import { useQuery } from "@tanstack/react-query";
import CakeElement from "../components/cakes/CakeElement";
import {getCakes, getCakesByCategory } from "../services/apiCakes";
import { useParams } from "react-router-dom";

function Cakes() {
const { categoryId } = useParams(); // Get the categoryId from the URL

  // Use React Query to fetch categories
const { data :cakes, error, isLoading } =  useQuery(
  Number(categoryId) === -1 ?{
  queryKey: ["cakes"],
  queryFn: getCakes,
}:
{
  queryKey: ['cakes', categoryId], // Unique key including categoryId
  queryFn: () => getCakesByCategory(categoryId), // Fetch function
});
  
console.log(cakes);
// Loading state
if (isLoading) return <div>Loading categories...</div>;

// Error state
if (error) return <div>Error loading categories</div>;
  return (
    <div className=" mt-20 flex justify-center flex-wrap  gap-10">
      {cakes.map((cake) => (
      <CakeElement key={cake.cakeID} cake={cake}/>
    ))}
    </div>
  )
}

export default Cakes
