import CategoryElement from "./CategoryElement";
import { useCategories } from "./hook/useCategories";

function Category() {
  const {  data :categories, error , isLoading}=useCategories();

if (isLoading) return <p>Loading ...</p>;
if (error) return <p>{error}</p>;

return (
    <section>
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
