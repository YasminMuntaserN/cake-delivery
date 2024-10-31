import { getAll ,addEntity ,DeleteEntity ,EditEntity, getBy} from "./BaseApi";


export const getAllCategories = async () => await getAll("categories");

export const addNewCategory = async (categoryInfo) => await addEntity("categories" ,categoryInfo);

export const editCategory = async (categoryInfo,categoryID) => await EditEntity("categories",categoryInfo,categoryID);

export const deleteCategory = async (categoryId) => await DeleteEntity("categories",categoryId);

export const getCategoryName = async (categoryId)=>await getBy("categories" , "categoryId" ,categoryId);
