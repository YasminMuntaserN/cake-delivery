import { useQuery } from "@tanstack/react-query";
import { getSales } from "../../../services/apiSales";
export function useSales() {
  const { data , error , isLoading}=useQuery({
    queryKey: ["sales"],
    queryFn: getSales,
  })
  return { data , error , isLoading}
};

