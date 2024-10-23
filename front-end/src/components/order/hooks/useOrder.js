import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { addNewOrder } from "../../../services/apiOrder";

export function useOrder() {
const queryClient = useQueryClient();

const { mutate: addOrder, isLoading: isAdding } = useMutation({
    mutationFn: addNewOrder,
    onSuccess: (data) => {
    const newOrderId = data.id;  
    toast.success("Order added successfully");
    queryClient.invalidateQueries({ queryKey: ["orders"] });
    return newOrderId;  
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isAdding, addOrder }; 
}