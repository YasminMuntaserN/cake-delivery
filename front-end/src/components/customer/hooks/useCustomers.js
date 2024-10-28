import { useQuery } from "@tanstack/react-query"
import { getCustomers } from "../../../services/apiCustomer";

function useCustomers() {

  const {data , error ,isLoading} =useQuery({
    queryKey: ["customers"],
    queryFn:getCustomers,
  });
  return  { data , error , isLoading}
}

export default useCustomers
