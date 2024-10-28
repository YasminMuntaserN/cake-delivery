
import TableHeader from "../../ui/TableHeader";
import Table from "../../ui/Table";
import { useCategories } from "./hook/useCategories";
import CategoryRow from "./CategoryRow";
import Loader from "../common/Loader";
import Error from "../common/Error";

function CategoriesTable() { 
    const {data:categories , error , isLoading}= useCategories();;
        if (isLoading) return <Loader />;
        if (error ) return <Error />;
        console.log(`categories: ${categories}`);
    return (
            <Table>
                <TableHeader gridColumns="grid-cols-[1fr_1fr_1fr_1fr]">
                    <div>Image</div>
                    <div>Category Name</div>
                    <div>Delete</div>
                    <div>Edit</div>
                </TableHeader>
                {categories.map((category) => (
                    <CategoryRow  category={category}  key={category.categoryID} />
                ))}
            </Table>
);
}

export default CategoriesTable