import { getAll ,getById ,getBy, addEntity, EditEntity ,DeleteEntity} from "./BaseApi";

const API_URL = import.meta.env.VITE_API_URL+'/cakes';

export const getCakes = async () => await getAll("cakes");

export const getCakesByCategory = async (categoryId) => await getBy("cakes","category" ,categoryId);

export const getCakeByName = async (cakeName) => await getBy("cake","name" ,cakeName);

export const getCakeById = async (cakeId) => await getById("cakes",cakeId);

export const addNewCake = async (cakeInfo) => await addEntity("cakes" ,cakeInfo);

export const fetchCakes = async (pageNumber) => await getByPageNumAndPgeSize("cakes",pageNumber);

export const editCake = async (cakeInfo,Id) => await EditEntity("cakes",cakeInfo,Id);

export const deleteCake = async (cakeId) => await DeleteEntity("cakes",cakeId);

export async function getTotalPages(Id) {
    try {
        const apiUrl = `${API_URL}/TotalPages/number/${Id}`;
        const res = await fetch(apiUrl, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
            },
        });

        if (!res.ok) {
            const errorDetails = await res.text(); 
            console.error('Failed to fetch total pages:', errorDetails);
            throw new Error('Failed to fetch total pages');
        }

        const data = await res.json();

        if (!data.totalRows || !data.totalPages) {
            throw new Error("Invalid response structure for total pages");
        }

        return data;
    } catch (error) {
        console.error("Error fetching total pages:", error);
        throw error; 
    }
}

export async function getByPageNumAndPgeSize(entityName ,pageNumber) {
if (pageNumber <= 0) {
    throw new Error("Page number and page size must be greater than zero.");
}
try {
    const res = await fetch(`${API_URL}/page/number/${pageNumber}?pageSize=${5}`, {
        headers: {
            'Accept': 'application/json',
        },
    });

    if (!res.ok) {
        throw new Error(`Failed to fetch ${entityName}`);
    }

    const data = await res.json();
  
    return data; 

  } catch (error) {
    throw error; 
}
}

export async function getTopCakes(){
    try {
        const res = await fetch(`${API_URL}/TopCakes`, {
            headers: {
                'Accept': 'application/json',
            },
        });

        if (!res.ok) {
            throw new Error(`Failed to fetch cakes`);
        }

        const data = await res.json();
        return data;  
    } catch (error) {

        console.error(`Error fetching cakes:`, error);
        throw error; 
    }
}
