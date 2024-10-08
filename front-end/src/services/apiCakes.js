const API_URL = "https://localhost:7085/api/cakes";

export async function getCakes() {
  try {
    const res = await fetch(`${API_URL}/All`, {
      headers: {
        'Accept': 'application/json',
      },
    });

    if (!res.ok) {
      throw new Error('Failed to fetch cakes');
    }

    const data = await res.json();

    return data;  // Return data if everything is successful
  } catch (error) {
    
    console.error("Error fetching cakes:", error);
    throw error;  // Re-throw the error to be handled by React Query
  }
}

export async function getCakesByCategory(categoryId) {
  try {
    const res = await fetch(`${API_URL}/category/${categoryId}`, {
      headers: {
        'Accept': 'application/json',
      },
    });

    if (!res.ok) {
      throw new Error('Failed to fetch cakes');
    }

    const data = await res.json();

    return data; // Return data if everything is successful
  } catch (error) {
    console.error("Error fetching cakes:", error);
    throw error; // Re-throw the error to be handled by React Query or your component
  }
}