import { useQuery } from "@tanstack/react-query";
import {getAllCategories} from "../../../services/apiCategories";
export function useCategories() {
  const { data , error , isLoading}=useQuery({
    queryKey: ["categories"],
    queryFn:getAllCategories,
  });
  console.log(`data : ${JSON.stringify(data)}`);
  return  { data , error , isLoading}

}

