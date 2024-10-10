import { useQuery } from "@tanstack/react-query";
import CakeElement from "./CakeElement";
import {getCakes, getCakesByCategory } from "../../services/apiCakes";
import { useParams } from "react-router-dom";


function CakesTable() {

 const { categoryId } = useParams();

  const { data: cakes = [], error, isLoading } = useQuery(
    Number(categoryId) === -1
      ? ["allCakes"] // Unique key for all cakes
      : ['cakesByCategory', Number(categoryId)], // Unique key for cakes by category
    Number(categoryId) === -1
      ? getCakes
      : () => getCakesByCategory(Number(categoryId))
  );

  console.log('cakes:', cakes);

  if (isLoading) return <div>Loading cakes...</div>;
  if (error) return <div>Error loading cakes</div>;


  return (
      <div className="mt-20 flex justify-center flex-wrap gap-10">
        {cakes.map((cake) => (
          <CakeElement key={cake.cakeID} cake={cake} />
        ))}
      </div>
  );
}

export default CakesTable
