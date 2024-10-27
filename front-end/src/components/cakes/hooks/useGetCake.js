import { useMutation, useQueryClient } from "@tanstack/react-query";
import { getCakeById } from "../../../services/apiCakes";

export function useGetCake() {
  const queryClient = useQueryClient();

  const { mutate: getCake, isLoading: isAdding } = useMutation({
    mutationFn: getCakeById,
    onSuccess: (data) => {
      console.log("The cake info was fetched successfully");
      queryClient.invalidateQueries({ queryKey: ["cakes"] });
    },
    onError: (err) => {
      console.log(err.message || "An error occurred");
    },
  });

  return { isAdding, getCake };
}
