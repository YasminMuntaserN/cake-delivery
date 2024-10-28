
import TableHeader from "../../ui/TableHeader";
import Table from "../../ui/Table";
import Loader from "../common/Loader";
import Error from "../common/Error";
import useUsers from "./hooks/useUsers";
import UserRow from "./UserRow";

function UserTable() { 
    const {data:users , error , isLoading}= useUsers();;
        if (isLoading) return <Loader />;
        if (error ) return <Error />;
        console.log(users);
    return (
            <Table>
                <TableHeader gridColumns="grid-cols-[1fr_1fr_1fr_1fr]">
                    <div>Email</div>
                    <div>Delete</div>
                    <div>change Email</div>
                    <div>Change Password</div>
                </TableHeader>
                {users.map((user) => (
                    <UserRow  user={user}  key={user.userID} />
                ))}
            </Table>
);
}

export default UserTable