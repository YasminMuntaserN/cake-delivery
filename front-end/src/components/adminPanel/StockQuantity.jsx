import { useState } from "react";
import { useCakes } from "../cakes/cakeHooks/useCakes";
import useCakesPerPage from "../cakes/cakeHooks/useCakesPerPage";
import Pagination from "../cakes/Pagination";
import Error from "../common/Error";
import Loader from "../common/Loader";
import CakeStockQuantity from "./CakeStockQuantity";
import { usePagination } from "../cakes/cakeHooks/usePagination";

function StockQuantity() { 
    const [pageNumber , setPageNumber]=useState(1);
    const { cakes, error, isLoading }=useCakesPerPage({pageNumber});
    const {pagesNum ,error :pagesNumError, isLoading :pagesNumLoading} =usePagination({categoryId :-1});
        if (isLoading ||pagesNumLoading) return <Loader />;
        if (error || pagesNumError) return <Error />;
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
                    <div>Delete</div>
                    <div>Edit</div>
                </header>
                {cakes.map((cake) => (
                    <CakeStockQuantity  cake={cake}  key={cake.cakeID} />
                ))}
                </div>
        <Pagination totalPages={pagesNum.totalPages} pageNumber={pageNumber} OnPageNumber ={setPageNumber}/>
        </div>
);
}
const styledTable = "w-full lg:mx-[60px] sm:mx-[30px] mt-10 border border-grey-200 text-[1.1rem] bg-grey-0 rounded-[7px] overflow-hidden p-5"
const StyledDate= "flex justify-between items-center text-xl border-2 border-grey-200 p-5 text-pink font-bold "
const styledTableHeader = " grid grid-cols-[1.8fr_1.8fr_0.7fr_0.7fr_0.7fr] gap-[3.4rem] items-center bg-grey-50 border-b order-grey-100  uppercase tracking-[0.4px]  text-grey-600 p-[10px_20px] text-sm"

export default StockQuantity
