import { getAll ,addEntity } from "./BaseApi";

export const getAllCategories = async () => await getAll("categories");

export const addNewCategory = async (categoryInfo) => await addEntity("categories" ,categoryInfo);
