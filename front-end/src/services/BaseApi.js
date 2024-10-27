const API_URL = import.meta.env.VITE_API_URL;

export async function getAll(entityName) {
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
        console.log(`data is getAll: ${JSON.stringify(data)}`);
        return data;  
    } catch (error) {

        console.error(`Error fetching ${entityName}:`, error);
        throw error; 
    }
}

export async function getBy(entityName,type ,value){
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

export async function addEntity(entityName, entityData) {
    console.log(`entityData: ${entityData}`); 
    try {
        const response = await fetch(`${API_URL}/${entityName}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: entityData, 
        });
        console.log(response);
        if (response.ok) {
            const data = await response.json();
            
            return data.split('/').pop();
        } else {
            const errorText = await response.text();
            throw new Error(`Error adding : ${errorText}`);
        }
    } catch (error) {
        console.error(`Error adding ${entityName}:`, error);
        throw error;
    }
}

export async function EditEntity(entityName, entityData ,id ) {
    console.log(`id: ${id}`); 
    console.log(`${API_URL}/${entityName}/${id}`); 

    try {
        const response = await fetch(`${API_URL}/${entityName}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(entityData), 
        });
        console.log(response);
        if (response.ok) {
            const data = await response.json();
            
            return data;
        } else {
            const errorText = await response.text();
            throw new Error(`Error Updating : ${errorText}`);
        }
    } catch (error) {
        console.error(`Error Updating ${entityName}:`, error);
        throw error;
    }
}

export async function DeleteEntity(entityName,id ) {
    console.log(`id: ${id}`); 
    console.log(`${API_URL}/${entityName}/${id}`); 

    try {
        const response = await fetch(`${API_URL}/${entityName}/${id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            }
        });
        console.log(response);
        if (response.ok) {
            const data = await response.json();
            return data;
        } else {
            const errorText = await response.text();
            throw new Error(`Error Deleting : ${errorText}`);
        }
    } catch (error) {
        console.error(`Error Deleting ${entityName}:`, error);
        throw error;
    }
}

