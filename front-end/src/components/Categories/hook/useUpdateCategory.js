import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { editCategory } from "../../../services/apiCategories";

export function useUpdateCategory() {
const queryClient = useQueryClient();

const { mutate: updateCategory, isLoading } = useMutation({
    mutationFn: editCategory,
    onSuccess: () => {
    toast.success("Category Updated successfully");
    queryClient.invalidateQueries({ queryKey: ["categories"] });
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isLoading, updateCategory }; 
}