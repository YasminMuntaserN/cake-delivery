import Delete from "../common/operations/Delete";
import Edit from "../common/operations/Edit";

function CategoryRow({category }) {
  console.log(`category CategoryRow: ${category}`);  
  return (
    <div className={styledRow }>
        <img className={styledImage}  src={category.categoryImageUrl} alt={category.categoryName} />
        <p>{category.categoryName}</p>
        <Delete id={category.categoryID} entity="Category"/>
        <Edit category={category}/>
    </div>
);
}
const styledRow = `grid  grid-cols-[1fr_1fr_1fr_1fr]  gap-[2.4rem] items-center border-b border-gray-100 px-5 py-5 text-xs`;
const styledImage = "ml-[20px] block w-1/6 object-cover transform scale-[150%] translate-x-[-7px]";
export default CategoryRow