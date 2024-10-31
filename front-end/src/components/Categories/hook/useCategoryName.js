import { useQuery } from "@tanstack/react-query";
import {getCategoryName} from "../../../services/apiCategories";

export function useCategoryName(categoryId) {
  const { data , error , isLoading}=useQuery({
    queryKey: ["categories" ,categoryId],
    queryFn:()=>getCategoryName(categoryId),
  });
  return  { data , error , isLoading}

}