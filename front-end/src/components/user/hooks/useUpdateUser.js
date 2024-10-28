import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { editUser } from "../../../services/apiUser";

export function useUpdateUser() {
const queryClient = useQueryClient();

const { mutate: updateUser, isLoading } = useMutation({
    mutationFn: editUser,
    onSuccess: () => {
    toast.success("User Updated successfully");
    queryClient.invalidateQueries({ queryKey: ["users"] });
    },
    onError: (err) => {
    toast.error(err.message || "An error occurred");
    },
});

return { isLoading, updateUser }; 
}