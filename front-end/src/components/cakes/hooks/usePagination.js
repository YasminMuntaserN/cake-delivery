import { useQuery } from "@tanstack/react-query";
import { getTotalPages } from "../../../services/apiCakes";

export function usePagination({ categoryId }) {
  const { data: pagesNum, error, isLoading } = useQuery({
    queryKey: ["pagesNum", { categoryId }],  
    queryFn: () => getTotalPages(categoryId),
  });

  return { pagesNum, error, isLoading };
}
