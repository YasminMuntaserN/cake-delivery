import { useQuery } from "@tanstack/react-query";
import { getCakeById } from "../services/apiCakes";

export function useCake(cakeID){
  const { data: cake, isLoading, error } = useQuery(
    {
        queryKey: ['cakes', cakeID],
        queryFn: () => getCakeById(cakeID),
        enabled: !!cakeID, 
    }
);
    return {cake , isLoading, error};

}