import { useNavigate } from "react-router-dom";
import Button from "../../ui/Button"

function StarterSection() {
  const navigate =useNavigate();
  return (
    <section>
    <div className={StyledContainer}>
      <div className={StyledSubContainer}>
        <h1 className={StyledHeader}>Baking Happiness, Olne Cake at a Time!</h1>
        <p className={StyledDescription}>Celebrate Lifes Moments with Our Signature Cakes!</p>
        
        <Button onClick={() => navigate("/cakes/-1")}> Order Your Cake Today 🎉 </Button>

        <div className={StyledShippingContainer}>
        <p className="text-sm font-semibold text-pink-600 mb-2">
          <img src="./transport.png"className="w-7 inline-grid mr-4" alt="starter-img"/>
          No shipping charge
        </p>
        <p className="text-sm font-semibold text-pink-600">
        <img src="./secure.png" className="w-7 inline-grid mr-4" alt="checkout-img"/>
          100% secure checkout</p>
          </div>
      </div>

      <div className="lg:w-1/2 mb-6 lg:mb-0 flex justify-center">
      <div className="w-100 h-70 rounded-full overflow-hidden  animate-bounce ">
        <img src="./cake-truck-delivery-.png" alt="Delicious Cake" className="h-full w-full object-cover transition-transform duration-1000 hover:scale-110 mt-[50px]" />
      </div>
    </div>
    </div>
    
    </section>
  )
}
const StyledContainer ="flex flex-col lg:flex-row items-center justify-between p-10 bg-gray-100 ";
const StyledSubContainer ="lg:mt-[-200px] mx-[50px] lg:w-1/2 flex flex-col justify-center p-6 text-center lg:text-left ";
const StyledHeader=" text-3xl lg:text-4xl font-bold text-basic mb-4";
const StyledDescription ="font-sans  text-lg text-basic mb-4";
const StyledShippingContainer ="flex items-center justify-between mt-4 mx-10";
export default StarterSection
