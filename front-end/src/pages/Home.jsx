function Home() {
  return (
    <section>
<div className="flex flex-col lg:flex-row items-center justify-between p-10 bg-gray-100">
      <div className="lg:w-1/2 mb-6 lg:mb-0">
        <img src="./cake-truck-delivery-.png" alt="Delicious Cake" className="rounded-lg shadow-lg object-cover h-full w-full" />
      </div>

      {/* Right Text Content */}
      <div className="lg:w-1/2 flex flex-col justify-center p-6">
        <h1 className="text-4xl font-bold text-gray-800 mb-4">Baking Happiness, One Cake at a Time!</h1>
        <p className="text-lg text-gray-700 mb-4">Celebrate Lifes Moments with Our Signature Cakes!</p>
        
        <p className="text-xl font-semibold text-pink-600 mb-2">No shipping charge</p>
        <p className="text-xl font-semibold text-pink-600">100% secure checkout</p>

        <button className="mt-4 px-6 py-2 bg-pink-600 text-white rounded-md shadow hover:bg-pink-700 transition duration-300">
          Order Your Cake Today!
        </button>
      </div>
    </div>
  );
    </section>
  )
}

export default Home
