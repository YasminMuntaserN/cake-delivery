import { useQuery} from "@tanstack/react-query";
import {getTopCakes } from "../../../services/apiCakes";

export function useGetTopCakes() {
  const { data: TopCakes = [], error, isLoading  } = useQuery({
    queryKey: ["cakes"],
    queryFn: getTopCakes,
  });
  return { TopCakes, error, isLoading };
}