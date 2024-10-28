import { addEntity, getAll } from "./BaseApi"

export const  getCustomers= async ()=> await getAll("customers");

export const  addNewCustomer= async (customerInfo)=> await addEntity("customers" ,customerInfo);


