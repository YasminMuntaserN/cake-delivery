import { useMutation, useQueryClient } from "@tanstack/react-query";
import { addNewCustomer } from "../../../services/apiCustomer";
import toast from "react-hot-toast";

export function useCustomer() {
    const queryClient = useQueryClient();

    const { mutate: addCustomer, isLoading: isAdding ,data :id } = useMutation({
        mutationFn: addNewCustomer,
        onSuccess: () => {
            toast.success('Customer added successfully');
            queryClient.invalidateQueries({ queryKey: ["customers"] });
        },
        onError: (err) => {
            toast.error(err.message || 'An error occurred');
        },
    });

    console.log(id);

    return { isAdding, addCustomer ,id }; 
}
