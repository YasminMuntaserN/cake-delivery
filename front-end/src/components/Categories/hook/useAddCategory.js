import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { addNewCategory } from "../../../services/apiCategories";

export function useAddCategory() {
const queryClient = useQueryClient();

const { mutate: addCategory, isLoading: isAdding } = useMutation({
    mutationFn : addNewCategory,
    onSuccess: (data) => {
    const newCategoryId = data.id;  
    toast.success("Category added successfully");
    queryClient.invalidateQueries({ queryKey: ["categories"] });
    return newCategoryId;  
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isAdding, addCategory }; 
}