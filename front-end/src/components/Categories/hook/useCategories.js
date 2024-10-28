import { useQuery } from "@tanstack/react-query";
import {getAllCategories} from "../../../services/apiCategories";
import { getUsers } from "../../../services/apiUser";

export function useCategories() {
  const { data , error , isLoading}=useQuery({
    queryKey: ["categories"],
    queryFn:getUsers,
  });
  return  { data , error , isLoading}

}


