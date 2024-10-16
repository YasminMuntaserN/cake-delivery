import { useEffect, useState } from 'react';
import Modal from '../../ui/Modal';
import CakeCard from'./CakeCard';
import { getCakeById } from "../../services/apiCakes";
import CakeItem from './CakeItem';


function CakeElement({ cake }) {
  const [cakeID, setCakeID] = useState(null); 
  const [clickedCake, setClickedCake] = useState(null); 
  
  useEffect(() => {
    if (cakeID) {
      const fetchCakeData = async () => {
        try {
          const fetchedCake = await getCakeById(cakeID);
          setClickedCake(fetchedCake);
        } catch (err) {
          console.error('Error fetching cake data:', err);
        }
      };
      fetchCakeData();
    }
  }, [cakeID]); 


  return (
    <Modal>
      <Modal.Open opens="cake-card" onClick={() => {setCakeID(cake.cakeID)}}>
      <div className={StyledContainer}>
          <CakeItem cake={cake}/>
      </div>
      </Modal.Open>
      <Modal.Window name="cake-card">
          <CakeCard cake={clickedCake} /> 
      </Modal.Window>
    </Modal>
  );
}

export default CakeElement;
const StyledContainer = 'border border-red-200 text-center p-8 cursor-pointer h-full min-h-[19rem]';
