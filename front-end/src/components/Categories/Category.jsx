import { getCategories } from "../../services/apiCategories";
import CategoryElement from "./CategoryElement";
import { useQuery } from "@tanstack/react-query";
import Loader from "../common/Loader";
import Error from "../common/Error";

function Category() {

const { data :categories, error, isLoading } = useQuery({
  queryKey: ["categories"],
  queryFn: getCategories,
});

if (isLoading) return  <Loader />;

if (error) return <Error/>;

return (
    <section className="mb-28">
      <div className="mt-11 mb-[-100px] " >
      <h2 className="text-[40px] text-center text-basic font-sans font-bold">Bringing joy to your celebrations, one slice at a tim🧚‍♀️</h2>
      <p className="text-center text-peach font-sans font-bold">A cake for every occasion</p>
      </div>
     <div className="flex justify-center items-center h-screen lg:mt-0 sm:mt-16"> 
      <div className="flex flex-wrap  mt-0 gap-10  justify-center items-center">
      {categories.map((Category) => (
      <CategoryElement key={Category.
        categoryID} Category={Category} />
    ))}
      </div>
      </div>

    </section>
  );
}



export default Category
