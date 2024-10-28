import { useMutation, useQueryClient } from "@tanstack/react-query";
import { addNewOrderItem } from "../../../services/apiOrderItem";
import toast from "react-hot-toast";

function useOrderItem() {
  console.log("we are here in useOrderItem");
  const queryClient = useQueryClient();

const { mutate: newOrderItem, isLoading: isAdding } = useMutation({
    mutationFn: addNewOrderItem,
    onSuccess: (data) => {
    queryClient.invalidateQueries({ queryKey: ["orderItems"] });
    console.log(` Order item added successfully for ${data}`);
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    console.log(`order items ${err}`);
    },
});

return { isAdding, newOrderItem }; 
}


export default useOrderItem
