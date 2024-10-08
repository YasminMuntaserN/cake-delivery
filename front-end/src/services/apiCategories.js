const API_URL = "https://localhost:7085/api/categories";

export async function getCategories() {
  try {
    const res = await fetch(`${API_URL}/All`, {
      headers: {
        'Accept': 'application/json',
      },
    });

    if (!res.ok) {
      throw new Error('Failed to fetch categories');
    }

    const data = await res.json();

    return data;  // Return data if everything is successful
  } catch (error) {
    
    console.error("Error fetching categories:", error);
    throw error;  // Re-throw the error to be handled by React Query
  }
}