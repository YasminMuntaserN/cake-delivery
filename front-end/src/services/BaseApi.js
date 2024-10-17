const API_URL = import.meta.env.VITE_API_URL;

export async function getAll(entityName) {
console.log(`${API_URL}/${entityName}/All`);
    try {
        const res = await fetch(`${API_URL}/${entityName}/All`, {
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

        console.error(`Error fetching ${entityName}:`, error);
        throw error; 
    }
}

export async function getBy(entityName,type ,value){
    console.log(`${API_URL}/${entityName}/${type}/${value}`);
    try {
    const res = await fetch(`${API_URL}/${entityName}/${type}/${value}`, {
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
    console.error(`Error fetching ${entityName}:`, error);
    throw error;
}
}

export async function getById(entityName ,value){
  console.log(`from getById : ${API_URL}/${entityName}/${value}`);
  try {
    const res = await fetch(`${API_URL}/${entityName}/${value}`, {
        headers: {
            'Accept': 'application/json',
        },
    });

    if (!res.ok) {
        throw new Error(`Failed to fetch ${entityName} with Id ${value}`);
    }

    const data = await res.json();

    return data;
} catch (error) {
    console.error(`Error fetching ${entityName} with Id ${value}:`, error);
    throw error;
}
}

export async function getByPageNumAndPgeSize(entityName ,pageNumber, pageSize) {

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
        throw new Error(`Failed to fetch ${entityName}`);
    }

    const data = await res.json();
  
    return data; 

  } catch (error) {
    throw error; 
}
}

