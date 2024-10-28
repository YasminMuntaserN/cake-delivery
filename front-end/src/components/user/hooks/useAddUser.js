import toast from "react-hot-toast";
import { addNewUser } from "../../../services/apiUser";
import { useMutation, useQueryClient } from "@tanstack/react-query";

export function useAddUser() {
  const queryClient = useQueryClient();

  const { mutate: addUser, isLoading: isAdding } = useMutation({
      mutationFn: addNewUser,
      onSuccess: (data) => {
      toast.success("User added successfully");
      queryClient.invalidateQueries({ queryKey: ["users"] });
      return data;  
      },
      onError: (err) => {
      toast.error(err.message || "An error occurred");
      },
  });
  
  return { isAdding, addUser }; 
  }
