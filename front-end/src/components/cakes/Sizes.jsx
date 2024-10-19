import { useContext } from "react";
import Button from "../../ui/Button"
import { CartItemsContext } from '../../context/CartItemsContext';

function Sizes({cake}) {
  const {handleSize} = useContext(CartItemsContext);
  return (
    <div className="StyledContainer">
      <Button type="Circle" onClick={()=>handleSize(cake.cakeID, 1)}>
      🤌 Small
      </Button>
      <Button type="Circle" onClick={()=>handleSize(cake.cakeID, 2)}>
      🫳 medium
      </Button>
      <Button type="Circle" onClick={()=>handleSize(cake.cakeID, 3)}>
      🫴 large
      </Button>
    </div>
  )
}
const StyledContainer ="flex flex-col items-center justify-between mt-100";
export default Sizes
