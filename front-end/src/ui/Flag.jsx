import { useEffect, useState } from "react";

function Flag({countryName}) {
  
  const [flagUrl, setFlagUrl] = useState(null);

  useEffect(
    ()=>{
      async function handleFetchFlag(){
        if (!countryName) return;

        try {
          const response = await fetch(`https://restcountries.com/v3.1/name/${countryName}`);
          const data = await response.json();
    
          if (data && data[0] && data[0].flags) {
            setFlagUrl(data[0].flags.png); 
          } else {
            alert('Flag not found!');
          }
        } catch (error) {
          console.error('Error fetching the flag:', error);
          alert('Could not fetch the flag. Please try again.');
        }
      }
      handleFetchFlag();
    },[countryName]);


  return (
    <div>
      {flagUrl && (
        <div>
          <img src={flagUrl} alt={`Flag of ${countryName}`} width="30" />
        </div>
      )}
    </div>
  );
}

export default Flag;
