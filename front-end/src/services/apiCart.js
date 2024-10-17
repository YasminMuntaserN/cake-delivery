const API_URL = import.meta.env.VITE_API_URL;

export async function getOrderItems() {

    try {
        const res = await fetch(`${API_URL}/All`, {
            headers: {
                'Accept': 'application/json',
            },
        });

        if (!res.ok) {
            throw new Error('Failed to fetch OrderItems');
        }

        const data = await res.json();

        return data;
    } catch (error) {

        console.error("Error fetching OrderItems:", error);
        throw error;
    }
}

export async function addOrderItems({orderID ,cakeID,quantity,sizeID ,pricePerItem}) {

    try {
        const res = await fetch(`${API_URL}/All`, {
            headers: {
                'Accept': 'application/json',
            },
        });

        if (!res.ok) {
            throw new Error('Failed to fetch OrderItems');
        }

        const data = await res.json();

        return data;
    } catch (error) {

        console.error("Error fetching OrderItems:", error);
        throw error;
    }
}