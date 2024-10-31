import Delete from "../common/operations/Delete";
import Edit from "../common/operations/Edit";
import Image from "../../ui/Image";
import { useCategoryName } from "../Categories/hook/useCategoryName";

function CakeRow({cake ,onPageNumber}) {
  const {data :categoryName , error , isLoading}=useCategoryName(cake.categoryID);
  const StyledStockQuantity = `rounded-full p-3 w-10 h-5 flex items-center ${
    cake.stockQuantity === 0 
      ? "bg-red-500" 
      : cake.stockQuantity <= 10 
      ? "bg-blue-500" 
      : "bg-green-500"
  }`;
  return (
    <div className={styledRow }>
        <Image src={cake.imageUrl} alt={cake.cakeName} className={styledImage}  entity="cakes" />
        <p>{cake.cakeName}</p>
        <div className={StyledStockQuantity}><p >{cake.stockQuantity}</p></div>
          <div>{cake.price}</div>
          <div>{isLoading ? "loading...." :error?"something get wrong " :categoryName}</div>
        <Delete isDeleting={true} id={cake.cakeID} onPageNumber={onPageNumber} entity="Cake"/>
        <Edit isUpdating ={true} cake={cake}/>
    </div>
);
}
const styledRow = `grid  grid-cols-[1fr_1fr_1fr_1fr_1fr_0.5fr_0.5fr]  gap-[2.4rem] items-center border-b border-gray-100 px-5 py-5 text-xs`;
const styledImage = "ml-[20px] block w-1/3 object-cover transform scale-[150%] translate-x-[-7px]";
export default CakeRow
