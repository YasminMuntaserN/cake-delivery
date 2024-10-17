import { useQuery } from "@tanstack/react-query";
import { getTotalPages } from "../../../services/apiCakes";
import { useParams } from "react-router-dom";

export function usePagination() {
  const { categoryId } = useParams(); 

  const { data: pagesNum, error, isLoading } = useQuery({
      queryKey: ["pagesNum", categoryId],
      queryFn: () => getTotalPages(categoryId),
  });
  return {pagesNum ,error, isLoading};
}

