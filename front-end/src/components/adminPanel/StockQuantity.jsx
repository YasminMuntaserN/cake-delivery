import Pagination from "../cakes/Pagination";
import Error from "../common/Error";
import Loader from "../common/Loader";
import CakeStockQuantity from "./CakeStockQuantity";
import { useCakeOperations } from "../../context/CakeContext";
import {useCakesPerPage} from "../cakes/hooks/useCakesPerPage";

function StockQuantity({typeToUseWith = "inDashboard"}) { 
    const styledTableHeader = ` grid 
        ${(typeToUseWith ==="cakeTable") ?
" grid-cols-[1fr_1fr_1fr_1fr_1fr_0.5fr_0.5fr] text-sm tracking-[0.4px] " :
" grid-cols-[1fr_1fr_1fr_1fr_0.5fr] text-xs tracking-[0.2px] "}
gap- [2.4rem] items-center bg-grey-50 border-b order-grey-100  uppercase  text-grey-600 p-[10px_20px] `;
    const {pageNumber ,setPageNumber}=useCakeOperations();
    const { cakes, error, isLoading }= useCakesPerPage({pageNumber});
        if (isLoading) return <Loader />;
        if (error ) return <Error />;
        const today = new Date();
    return (
        <div>
        <div role="table" className={styledTable}>
                <div className={StyledDate}>
                <p> Today</p>
                <span> 🗓️ {today.toLocaleDateString("en-US" , { year: 'numeric', month: 'long', day: 'numeric' })}</span>
                </div>
                <header role="row" className={styledTableHeader}>
                    <div>Image</div>
                    <div>Cake Name</div>
                    <div>Stock Quantity</div>
                    {(typeToUseWith ==="cakeTable") &&
                    <>
                    <div>Price</div>
                    <div>Category Type</div>
                    </>
                    }
                    <div>Delete</div>
                    <div>Edit</div>
                </header>
                {cakes.map((cake) => (
                    <CakeStockQuantity typeToUseWith={typeToUseWith} cake={cake}  key={cake.cakeID} />
                ))}
                </div>
        <Pagination pageNumber={pageNumber} OnPageNumber ={setPageNumber}/>
        </div>
);
}
const styledTable = " lg:mx-[60px] sm:mx-[30px] mt-10 border border-grey-200 text-[1.1rem] bg-grey-0 rounded-[7px] overflow-hidden p-5"
const StyledDate= "flex justify-between items-center text-xl border-2 border-grey-200 p-5 text-pink font-bold "


export default StockQuantity
