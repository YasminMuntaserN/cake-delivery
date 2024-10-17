import { getAll ,getById ,getBy, getByPageNumAndPgeSize } from "./BaseApi";

const API_URL = import.meta.env.VITE_API_URL+'/cakes';

export const getCakes = async () => await getAll("cakes");


export const getCakesByCategory = async (categoryId) => await getBy("cakes","category" ,categoryId);



export const getCakeByName = async (cakeName) => await getBy("cake","name" ,cakeName);


export const getCakeById = async (cakeId) => await getById("cakes",cakeId);


export const fetchCakes = async (pageNumber = 1, pageSize = 10) => await getByPageNumAndPgeSize("cakes",pageNumber,pageSize);


export async function getTotalPages(Id) {
    try {
        console.log("getTotalPages method called with categoryId:", Id);
        const apiUrl = `${API_URL}/TotalPages/number/${Id}`; // Check this URL is correct
        console.log('apiUrl:', apiUrl);
        const res = await fetch(apiUrl, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
            },
        });
        console.log('res:', res);

        if (!res.ok) {
            const errorDetails = await res.text(); // Log response details
            console.error('Failed to fetch total pages:', errorDetails);
            throw new Error('Failed to fetch total pages');
        }

        const data = await res.json();
        console.log('Pagination data received:', data);

        if (!data.totalRows || !data.totalPages) {
            throw new Error("Invalid response structure for total pages");
        }

        return data;
    } catch (error) {
        console.error("Error fetching total pages:", error);
        throw error; // Re-throw the error for React Query to handle
    }
}




