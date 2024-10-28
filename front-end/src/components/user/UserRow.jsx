import Delete from "../common/operations/Delete";
import UpdateUser from "./UpdateUser";

function UserRow({user }) {
  console.log(`user userRow: ${user}`);  
  return (
    <div className={styledRow }>
        <p>{user.email}</p>
        <Delete id={user.userID} entity="User"/>
        <UpdateUser operationName="email" user={user} />
        <UpdateUser operationName="password" user={user} />
    </div>
);
}
const styledRow = `grid  grid-cols-[1fr_1fr_1fr_1fr]  gap-[2.4rem] items-center border-b border-gray-100 px-5 py-5 text-xs`;
const styledImage = "ml-[20px] block w-1/6 object-cover transform scale-[150%] translate-x-[-7px]";
export default UserRow