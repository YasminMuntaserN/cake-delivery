import Pagination from "../cakes/Pagination";
import Error from "../common/Error";
import Loader from "../common/Loader";
import CakeStockQuantity from "./CakeRow";
import { useCakeOperations } from "../../context/CakeContext";
import {useCakesPerPage} from "../cakes/hooks/useCakesPerPage";
import TableHeader from "../../ui/TableHeader";
import Table from "../../ui/Table";
import Empty from "../../ui/Empty";

function CakesTable() { 

    const {pageNumber ,setPageNumber}=useCakeOperations();
    const { cakes, error, isLoading }= useCakesPerPage({pageNumber});
        if (isLoading) return <Loader />;
        if (error ) return <Error />;
    return (
        <div>
            <Table>
                <TableHeader gridColumns="grid-cols-[1fr_1fr_1fr_1fr_1fr_0.5fr_0.5fr]">
                    <div>Image</div>
                    <div>Cake Name</div>
                    <div>Stock Quantity</div>
                    <div>Price</div>
                    <div>Category Type</div>
                    <div>Delete</div>
                    <div>Edit</div>
                </TableHeader>
                {
                cakes ? 
                cakes.map((cake) => (
                    <CakeStockQuantity  cake={cake}  key={cake.cakeID} />
                )) :<Empty resourceName="Cakes" />
                }

            </Table>
        <Pagination pageNumber={pageNumber} OnPageNumber ={setPageNumber}/>
        </div>
);
}

export default CakesTable
