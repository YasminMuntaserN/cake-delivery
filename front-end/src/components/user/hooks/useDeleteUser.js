import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { deleteUser } from "../../../services/apiUser";

export function useDeleteUser() {
const queryClient = useQueryClient();
const { mutate: deleteUserObject, isLoading } = useMutation({
    mutationFn: deleteUser,
    onSuccess: () => {
    toast.success("User Deleted successfully");
    queryClient.invalidateQueries({ queryKey: ["users"] });
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isLoading, deleteUserObject }; 
}