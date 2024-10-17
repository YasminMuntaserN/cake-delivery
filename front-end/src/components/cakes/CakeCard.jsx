import { formatCurrency } from "../../utils/helper";

function CakeCard({ cake }) {
  if (!cake) return <div>Loading...</div>;

  return (
    <div className={styleContainer}>
      <div className={styledImageContainer}>
        <img src={cake.imageUrl} className={styledImage} alt={cake.cakeName} />
      </div>
      <div className={styledDetails}>
        <h2 className={styleName}>{cake.cakeName}</h2>
        <p className={styleCaption}>Made with all Love ❤️</p>
        <p className={styleDescription}>{cake.description}</p>
        <p className="text-pink mt-4">Price: <span>{formatCurrency(cake.price)}</span></p>
      </div>
    </div>
  );
}

const styleContainer = "flex rounded-lg overflow-hidden p-2 ";
const styledImageContainer = "w-1/2 h-auto overflow-hidden sm:w-1/4 "; 
const styledImage = "w-full h-full object-cover object-center transition-transform duration-500 transform hover:scale-110 ";
const styledDetails = "flex flex-col justify-center p-4 w-1/2"; 
const styleName = "font-bold text-xl text-pink text-center sm:text-2xl mb-1";
const styleCaption = "text-sm text-peach text-center sm:text-md mb-2";
const styleDescription = "mt-2 font-light text-basic lg:text-lg sm:text-md text-center";


export default CakeCard;