import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { addNewCake } from "../../../services/apiCakes";

export function useAddCake() {
const queryClient = useQueryClient();

const { mutate: addCake, isLoading: isAdding } = useMutation({
    mutationFn: addNewCake,
    onSuccess: (data) => {
    const newCakeId = data.id;  
    toast.success("Cake added successfully");
    queryClient.invalidateQueries({ queryKey: ["cakes"] });
    return newCakeId;  
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isAdding, addCake }; 
}