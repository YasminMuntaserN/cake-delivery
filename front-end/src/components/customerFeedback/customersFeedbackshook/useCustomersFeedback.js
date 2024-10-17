import { getCustomersFeedback } from "../../../services/apiCustomerFeedback";
import { useQuery } from "@tanstack/react-query";

export function useCustomersFeedback() {

  const { data :Feedbacks, error, isLoading } = useQuery({
    queryKey: ["Feedback"],
    queryFn: getCustomersFeedback,
  });

  return {Feedbacks ,error ,isLoading}
}

