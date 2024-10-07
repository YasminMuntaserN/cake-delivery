import Button from "../components/Button"
import Category from "../components/Categories/Category";
import VideoLayout from "../components/common/VideoLayout";
function Home() {
  return (
    <>
    <section>
<div className="flex flex-col lg:flex-row items-center justify-between p-10 bg-gray-100 ">
      {/* Left Text Content */}
      <div className="lg:mt-[-200px] mx-[50px] lg:w-1/2 flex flex-col justify-center p-6 text-center lg:text-left ">
        <h1 className=" text-3xl lg:text-4xl font-bold text-basic mb-4">
          Baking Happiness, One Cake at a Time!
        </h1>
        <p className="font-sans  text-lg text-basic mb-4">
          Celebrate Lifes Moments with Our Signature Cakes!
        </p>
        
        <Button> Order Your Cake Today 🎉 </Button>

        <div className="flex items-center justify-between mt-4 mx-10">
        <p className="text-sm font-semibold text-pink-600 mb-2">
          <img src="./transport.png"className="w-7 inline-grid mr-4"/>
          No shipping charge
        </p>
        <p className="text-sm font-semibold text-pink-600">
        <img src="./secure.png" className="w-7 inline-grid mr-4"/>
          100% secure checkout</p>
          </div>

      </div>

      
      {/* Right Image */}
      <div className="lg:w-1/2 mb-6 lg:mb-0 flex justify-center">
      <div className="w-100 h-70 rounded-full overflow-hidden  animate-bounce ">
        <img src="./cake-truck-delivery-.png" alt="Delicious Cake" className="h-full w-full object-cover transition-transform duration-1000 hover:scale-110 mt-[50px]" />
      </div>
    </div>
    </div>
    
    </section>
    <Category />
    <VideoLayout/>
    <div className="h-[300px]">

    </div>
    </>
  )
}

export default Home
