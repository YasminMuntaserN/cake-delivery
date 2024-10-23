import { addEntity } from "./BaseApi"

export const  addNewOrderItem= async (orderItemInfo)=> await addEntity("orderItems" ,orderItemInfo);
