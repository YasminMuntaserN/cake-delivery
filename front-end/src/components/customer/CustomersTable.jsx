
import TableHeader from "../../ui/TableHeader";
import Table from "../../ui/Table";
import Loader from "../common/Loader";
import Error from "../common/Error";
import useCustomers from "./hooks/useCustomers";
import CustomerRow from "./CustomerRow";

function CustomersTable() { 
    const {data:customers , error , isLoading}= useCustomers();;
        if (isLoading) return <Loader />;
        if (error ) return <Error />;
    return (
            <Table>
                <TableHeader gridColumns="grid-cols-[2fr_2fr_2fr_1fr_1fr_1fr]">
                    <div>Name</div>
                    <div>Email</div>
                    <div>Phone Number</div>
                    <div>Address</div>
                    <div>City</div>
                    <div>postalCode</div>
                </TableHeader>
                {customers.map((customer) => (
                    <CustomerRow  customer={customer}  key={customer.customerID} />
                ))}
            </Table>
);
}

export default CustomersTable