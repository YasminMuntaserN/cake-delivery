import { useMutation, useQueryClient } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { Exist } from "../../services/apiUser";

export function useExistUser() {
const queryClient = useQueryClient();

const { mutate: existUser, isLoading } = useMutation({
    mutationFn: Exist,
    onSuccess: (data) => {
    console.log(" Exist User");
    queryClient.invalidateQueries({ queryKey: ["users"] });
    return data;
    },
    onError: (err) => {
      console.log(err.message || "An error occurred");
    },
});

return { isLoading, existUser }; 
}