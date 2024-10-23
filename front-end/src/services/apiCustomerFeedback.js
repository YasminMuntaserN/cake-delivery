import { addEntity, getAll } from "./BaseApi";

export const getCustomersFeedback = async () => await getAll("Feedbacks");

export const addNewCustomerFeedback = async (customerFeedbackInfo) => await addEntity("Feedbacks" ,customerFeedbackInfo);
