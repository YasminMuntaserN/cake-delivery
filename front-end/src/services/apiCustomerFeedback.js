import { getAll } from "./BaseApi";

export const getCustomersFeedback = async () => await getAll("Feedbacks");