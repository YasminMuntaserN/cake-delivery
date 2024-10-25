import { useQuery } from "@tanstack/react-query";
import { fetchCakes } from "../../../services/apiCakes";

function useCakesPerPage({pageNumber }) {
  console.log(` pageNumber ${pageNumber}`);
  const { data: cakes = [], error, isLoading } = useQuery(
          {
            queryKey: ['cakes', pageNumber], 
            queryFn: () =>fetchCakes( pageNumber), 
          })

  return { cakes, error, isLoading } 
}

export default useCakesPerPage
