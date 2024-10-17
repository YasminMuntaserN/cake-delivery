import { getAll } from "./BaseApi";

export const getCategories = async () => await getAll("categories");