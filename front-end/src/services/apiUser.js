const API_URL = import.meta.env.VITE_API_URL;

export async function Exist(data){
  const {email ,password} = data;  
  // 'https://localhost:7085/api/Users/Tesst%40test.com/12345678' \
  console.log(`${API_URL}/Users/${email}/${password}`);
  try {
  const res = await fetch(`${API_URL}/Users/${email}/${password}`, {
      headers: {
          'Accept': 'application/json',
      },
  });

  if (!res.ok) {
      throw new Error(`Failed to fetch User`);
  }
  console.log(res);  

  const data = await res.json();
  console.log(data);  
  return data;
} catch (error) {
  console.error(`Error fetching Users`, error);
  throw error;
}
}