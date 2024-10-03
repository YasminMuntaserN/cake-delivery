function Home() {
  return (
    <section>


<div className="flex flex-col lg:flex-row items-center justify-between p-10 bg-gray-100">
      {/* Left Text Content */}
      <div className="lg:mt-[-200px] lg:w-1/2 flex flex-col justify-center p-6 text-center lg:text-left">
        <h1 className="text-3xl lg:text-4xl font-bold text-basic mb-4">
          Baking Happiness, One Cake at a Time!
        </h1>
        <p className="text-lg text-basic mb-4">
          Celebrate Life's Moments with Our Signature Cakes!
        </p>
        
       
        <button className="mt-4 px-6 py-2 bg-pink-600 text-white rounded-md shadow hover:bg-pink-700 transition duration-300">
          Order Your Cake Today!
        </button>

        <div className="flex items-center justify-between ">
        <p className="text-sm font-semibold text-pink-600 mb-2">
          <img src="./transport.png"className="w-7 inline-grid mr-5"/>
          No shipping charge
        </p>
        <p className="text-sm font-semibold text-pink-600">
        <img src="./secure.png" className="w-7 inline-grid mr-5"/>
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
  )
}

export default Home
