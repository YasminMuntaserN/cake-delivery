import { useCategories } from "../Categories/hook/useCategories";

function CategorySelector({register ,OnCategoryChange}) {
  const {  data :categories, error , isLoading}=useCategories();

if (isLoading) return <p>Loading ...</p>;
if (error) return <p>{error}</p>;

console.log(categories);
  return (
    <select className={styledSelect} {...register("categoryId")} onChange={OnCategoryChange }>
    { categories.map((category) => (
          <option key={category.categoryID} value={category.categoryID}>
            {category.categoryName}
          </option>
        ))
    }
  </select>
  )
}
const styledSelect = "border border-red-200 text-basic  w-[300px] px-4 py-2 text-sm rounded-md  transition-all duration-300 focus:outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
export default CategorySelector
