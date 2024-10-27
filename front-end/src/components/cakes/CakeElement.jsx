import {  useState } from 'react';
import Modal from '../../ui/Modal';
import CakeCard from'./CakeCard';
import CakeItem from './CakeItem';
import { HiHeart } from 'react-icons/hi2';
import { useGetCake } from './hooks/useGetCake';


function CakeElement({ cake }) {
  const [clickedCake, setClickedCake] = useState(null); 
  const { getCake}=useGetCake();

  const handleGetCake = (id) => {
    getCake(id, {
      onSuccess: (data) => {
        console.log(data);
        setClickedCake(data);
      }
    });
  };

  return (
    <Modal>
      <div className={StyledContainer}>
          <CakeItem cake={cake}/>
          <Modal.Open opens="cake-card" onClick={() => {handleGetCake(cake.cakeID)}}>
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
