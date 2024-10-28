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

const styleContainer = "grid grid-cols-[auto_auto] gap-4 p-5";
const styledImageContainer = "mr-10"; 
const styledImage = "";
const styledDetails = ""; 
const styleName = "font-bold text-xl text-pink text-center sm:text-2xl mb-1";
const styleCaption = "text-sm text-peach text-center sm:text-md mb-2";
const styleDescription = "mt-2 font-light text-basic lg:text-lg sm:text-md text-center";

export default CakeCard;