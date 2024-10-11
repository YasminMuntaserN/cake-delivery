import { formatCurrency } from "../../utils/helper";

function CakeCard({cake}){
  return (
      <div>
        <img src={cake.imageUrl}/>
        <h2>{cake.cakeName}<span>Made with all Love❤️</span></h2>
        <p>{cake.description}</p>
        <p>Price : {formatCurrency(cake.price)}</p>
      </div>
  )
}
export default CakeCard;