import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { editCake } from "../../../services/apiCakes";

export function useUpdateCake() {
    const queryClient = useQueryClient();

    const { mutate: updateCake, isLoading } = useMutation({
        mutationFn: ({ cakeInfo, cakeID }) => editCake(cakeInfo, cakeID), 
        onSuccess: () => {
            toast.success("Cake Updated successfully");
            queryClient.invalidateQueries({ queryKey: ["cakes"] });
        },
        onError: (err) => {
            toast.error(err.message || "An error occurred");
        },
    });

    return { isLoading, updateCake }; 
}
