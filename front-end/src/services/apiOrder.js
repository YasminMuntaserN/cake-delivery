import { addEntity } from "./BaseApi"

export const  addNewOrder= async (orderInfo)=> await addEntity("orders" ,orderInfo);


