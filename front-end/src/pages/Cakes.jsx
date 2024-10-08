import CakeElement from "../components/cakes/CakeElement";

function Cakes() {
  const cakes = [
    {
      id: 61,
      name: "Monochrome Floating Tiers",
      description: "Elegant wedding featuring black ribbon and black floral veining, with a crisp monochrome design. Perfect for an elegant wedding theme.",
      price: 75.00,
      stock: 20,
      image: "https://cdn0.hitched.co.uk/article/5886/original/1280/png/136885-boutique-bakery.jpeg",
      dateAdded: "2024-09-23 09:36:53.510",
      category: 6
    },
    {
      id: 62,
      name: "Marbled Square Wedding",
      description: "Modern marbled icing wedding in peach and orange with unique square tiers. Ideal for a modern wedding theme.",
      price: 85.00,
      stock: 10,
      image: "https://cdn0.hitched.co.uk/article/7886/original/1280/png/136887-cakebuds4.jpeg",
      dateAdded: "2024-09-23 09:36:53.510",
      category: 6
    },
    {
      id: 63,
      name: "Draped Floating Wedding Cake",
      description: "Four-tier wedding with cement effect and floating tiers held up by a grey drape. Features a greyscale colour palette.",
      price: 90.00,
      stock: 10,
      image: "https://cdn0.hitched.co.uk/article/9886/original/1280/png/136889-cakebuds5.jpeg",
      dateAdded: "2024-09-23 09:36:53.510",
      category: 6
    },
    {
      id: 64,
      name: "Hand-Painted Illustrations",
      description: "Simple ivory wedding with hand-painted birds and flowers. Offers a personal touch with custom illustrations.",
      price: 70.00,
      stock: 10,
      image: "https://cdn0.hitched.co.uk/article/1986/original/1280/png/136891-cobi-coco-1.jpeg",
      dateAdded: "2024-09-23 09:36:53.510",
      category: 6
    },
    {
      id: 65,
      name: "Cascading Florals",
      description: "Five-tier ivory wedding with cascading ombre flower decorations, transitioning from white to dark pink. Elegantly adorned with fresh green foliage.",
      price: 95.00,
      stock: 10,
      image: "https://cdn0.hitched.co.uk/article/5986/original/1280/png/136895-deluce-cakes-4.jpeg",
      dateAdded: "2024-09-23 09:36:53.510",
      category: 6
    },
    {
      id: 66,
      name: "Pearl Beading Detail",
      description: "Pearlescent gold wedding with edible pearls and beading effect on the base tier. Features a sleek and elegant design.",
      price: 80.00,
      stock: 10,
      image: "https://cdn0.hitched.co.uk/article/7986/original/1280/png/136897-deluce-cakes-7.jpeg",
      dateAdded: "2024-09-23 09:36:53.510",
      category: 6
    }
  ];
  
  return (
    <div className=" mt-20 flex justify-center flex-wrap   gap-10">
      {cakes.map((cake) => (
      <CakeElement key={cake.id} cake={cake}/>
    ))}
    </div>
  )
}

export default Cakes
