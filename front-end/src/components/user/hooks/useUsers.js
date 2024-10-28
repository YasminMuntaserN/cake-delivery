import { useQuery } from "@tanstack/react-query"
import { getUsers } from "../../../services/apiUser";

function useUsers() {

  const {data , error ,isLoading} =useQuery({
    queryKey: ["users"],
    queryFn:getUsers,
  });
  return  { data , error , isLoading}
}

export default useUsers
