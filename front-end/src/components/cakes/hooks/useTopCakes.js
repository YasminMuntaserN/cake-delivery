import { useQuery} from "@tanstack/react-query";
import {getTopCakes } from "../../../services/apiCakes";

export function useGetTopCakes() {
  const { data: TopCakes = [], error, isLoading  } = useQuery({
    queryKey: ["cakes"],
    queryFn: getTopCakes,
  });
   console.log(TopCakes);
  return { TopCakes, error, isLoading };
}