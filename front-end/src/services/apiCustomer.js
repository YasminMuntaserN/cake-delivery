import { addEntity } from "./BaseApi"

export const  addNewCustomer= async (customerInfo)=> await addEntity("customers" ,customerInfo);
