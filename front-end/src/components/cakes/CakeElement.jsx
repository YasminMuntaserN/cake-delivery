import { useEffect, useState } from 'react';
import Modal from '../../ui/Modal';
import CakeCard from'./CakeCard';
import { getCakeById } from "../../services/apiCakes";
import CakeItem from './CakeItem';
import { HiHeart } from 'react-icons/hi2';


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
      <div className={StyledContainer}>
          <CakeItem cake={cake}/>
          <Modal.Open opens="cake-card" onClick={() => {setCakeID(cake.cakeID)}}>
                <HiHeart className={styledIcon}/>
            </Modal.Open>
      </div>
      <Modal.Window name="cake-card">
        <CakeCard cake={clickedCake} />
      </Modal.Window>
    </Modal>
  );
}

export default CakeElement;
const StyledContainer = 'border border-red-200 text-center p-8 cursor-pointer h-full min-h-[19rem] relative';

const styledIcon="text-red-500 text-xl absolute top-[10px] right-[10px]";
