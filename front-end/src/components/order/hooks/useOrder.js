import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { addNewOrder } from "../../../services/apiOrder";

export function useOrder() {
    const queryClient = useQueryClient();

    const { mutate: addOrder, isLoading: isAdding ,data :id } = useMutation({
        mutationFn: addNewOrder,
        onSuccess: () => {
            toast.success('Order added successfully');
            queryClient.invalidateQueries({ queryKey: ["orders"] });
        },
        onError: (err) => {
            toast.error(err.message || 'An error occurred');
        },
    });

    console.log(id);

    return { isAdding, addOrder ,id }; 
}