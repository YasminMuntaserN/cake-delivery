import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { deleteCategory } from "../../../services/apiCategories";

export function useDeleteCategory() {
const queryClient = useQueryClient();
const { mutate: deleteCategoryObject, isLoading } = useMutation({
    mutationFn: deleteCategory,
    onSuccess: () => {
    toast.success("Category Deleted successfully");
    queryClient.invalidateQueries({ queryKey: ["categories"] });
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isLoading, deleteCategoryObject }; 
}