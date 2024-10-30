import { useMutation, useQueryClient } from "@tanstack/react-query";
import { addNewCustomer } from "../../../services/apiCustomer";
import toast from "react-hot-toast";

export function useAddCustomer() {
    const queryClient = useQueryClient();

    const { mutate: addCustomer, isLoading: isAdding ,data :id } = useMutation({
        mutationFn: addNewCustomer,
        onSuccess: (data) => {
            const customerId = data.customerID;
            toast.success('Customer added successfully');
            queryClient.invalidateQueries({ queryKey: ["customers"] });
            return customerId;
        },
        onError: (err) => {
            toast.error(err.message || 'An error occurred');
        },
    });
    return { isAdding, addCustomer ,id }; 
}
