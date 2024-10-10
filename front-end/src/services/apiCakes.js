const API_URL = "https://localhost:7085/api/cakes";
export async function getCakes() {
  console.log("getCakesByCategory method called");

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

    return data; 
  } catch (error) {
    
    console.error("Error fetching cakes:", error);
    throw error;  
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

    return data; 
  } catch (error) {
    console.error("Error fetching cakes:", error);
    throw error; 
  }
}

export async function fetchCakes(pageNumber = 1, pageSize = 10) {
  console.log("fetchCakes method called");

  // Validate input parameters
  if (pageNumber <= 0 || pageSize <= 0) {
    throw new Error("Page number and page size must be greater than zero.");
  }

  try {
    const res = await fetch(`${API_URL}/page/number/${pageNumber}?pageSize=${pageSize}`, {
      headers: {
        'Accept': 'application/json',
      },
    });

    if (!res.ok) {
      const errorDetails = await res.text(); // Log response details
      console.error('Failed to fetch cakes:', errorDetails);
      throw new Error('Failed to fetch cakes');
    }

    const data = await res.json();
    console.log('Fetched cakes:', data); // Log the fetched cakes data
    return data; // Return data if everything is successful
  } catch (error) {
    console.error("Error fetching cakes:", error);
    throw error; // Re-throw the error to be handled by React Query or your component
  }
}

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




