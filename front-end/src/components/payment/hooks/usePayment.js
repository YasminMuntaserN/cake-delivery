import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { addNewPayment } from "../../../services/apiPayment";

export function usePayment() {
    const queryClient = useQueryClient();

    const { mutate: addPayment, isLoading: isAdding ,data :id } = useMutation({
        mutationFn: addNewPayment,
        onSuccess: () => {
            toast.success('your payment added successfully now just wait for one hour to Receive the Order 😋');
            queryClient.invalidateQueries({ queryKey: ["payments"] });
        },
        onError: (err) => {
            toast.error(err.message || 'An error occurred');
        },
    });

    console.log(id);

    return { isAdding, addPayment ,id }; 
}
