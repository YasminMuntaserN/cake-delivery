import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { deleteCake } from "../../../services/apiCakes";

export function useDeleteCake() {
const queryClient = useQueryClient();
console.log("looogin");
const { mutate: deleteCakeObject, isLoading } = useMutation({
    mutationFn: deleteCake,
    onSuccess: () => {
    toast.success("Cake Deleted successfully");
    queryClient.invalidateQueries({ queryKey: ["deleteCakes"] });
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isLoading, deleteCakeObject }; 
}