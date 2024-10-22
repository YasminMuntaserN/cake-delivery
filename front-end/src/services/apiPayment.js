import { addEntity } from "./BaseApi"

export const  addNewPayment= async (paymentInfo)=> await addEntity("payments" ,paymentInfo);


