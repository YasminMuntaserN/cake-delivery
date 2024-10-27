import { useQuery } from "@tanstack/react-query";
import { fetchCakes } from "../../../services/apiCakes";

export function useCakesPerPage({ pageNumber }) {
  const { data: cakes = [], error, isLoading } = useQuery({
    queryKey: ['cakes', { pageNumber }],  
    queryFn: () => fetchCakes(pageNumber),
  });

  return { cakes, error, isLoading };
}

