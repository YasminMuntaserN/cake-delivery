import { useMutation, useQueryClient } from "@tanstack/react-query";
import { ChangeStockQuantity } from "../../../services/apiCakes";

export function useStockQuantity() {
    const queryClient = useQueryClient();

    const { mutate: updateCakeStockQuantity, isLoading } = useMutation({
        mutationFn: ({cakeID ,stockQuantiy}) => ChangeStockQuantity(cakeID ,stockQuantiy), 
        onSuccess: () => {
            console.log("Cake Updated successfully");
            queryClient.invalidateQueries({ queryKey: ["cakes"] });
        },
        onError: (err) => {
            console.log(err.message || "An error occurred");
        },
    });

    return { isLoading, updateCakeStockQuantity }; 
}
