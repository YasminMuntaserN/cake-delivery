import CategoryElement from "./CategoryElement";

function Category() {
  const categories = [
    {
      CategoryID: 2,
      CategoryName: "Baby Shower",
      CategoryImageURL: "https://imgur.com/o4X0q9t.jpg",
    },
    {
      CategoryID: 3,
      CategoryName: "Birthday",
      CategoryImageURL: "https://imgur.com/iNP2nSI.jpg",
    },
    {
      CategoryID: 4,
      CategoryName: "Anniversary",
      CategoryImageURL: "https://imgur.com/dBRyXQe.jpg",
    },
    {
      CategoryID: 5,
      CategoryName: "Graduation",
      CategoryImageURL: "https://imgur.com/b7yDmT6.jpg",
    },
    {
      CategoryID: 6,
      CategoryName: "Wedding",
      CategoryImageURL: "https://imgur.com/QKm8p26.jpg",
    },
  ];

  return (
    <section>
      <div className="mt-11 mb-[-100px]" >
      <h2 className="text-[40px] text-center text-basic font-sans font-bold">Bringing joy to your celebrations, one slice at a tim🧚‍♀️</h2>
      <p className="text-center text-peach font-sans font-bold">A cake for every occasion</p></div>
     <div className="flex justify-center items-center h-screen "> 
      <div className="flex flex-wrap  mt-0 gap-10  justify-center items-center">
      {categories.map((Category) => (
      <CategoryElement key={Category.CategoryID} Category={Category} />
    ))}
      </div>
      </div>

    </section>
  );
}



export default Category
