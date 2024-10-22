import toast from "react-hot-toast";
import { addNewCustomerFeedback } from "../../../services/apiCustomerFeedback";
import { useMutation, useQueryClient } from "@tanstack/react-query";

export function useAddCustomersFeedback() {
  const queryClient =useQueryClient();

  const { mutate: addCustomerFeedback, isLoading: isAdding ,data :id } = useMutation({
    mutationFn: addNewCustomerFeedback,
    onSuccess: () => {
        toast.success('Customer Feedback added successfully');
        queryClient.invalidateQueries({ queryKey: ["Feedbacks"] });
    },
    onError: (err) => {
        toast.error(err.message || 'An error occurred');
    },
});

console.log(id);

return { isAdding, addCustomerFeedback ,id }; 
}