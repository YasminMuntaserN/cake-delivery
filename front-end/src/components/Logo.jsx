import { Link } from "react-router-dom";

function Logo() {
  return (
    <Link to="/">
      <div className="logo text-center hover:cursor-pointer">
        <img src="./logo.png" alt="CakeDelivery logo"className="w-[200px] object-contain  "/>
      </div>
    </Link>
  );
}

export default Logo;
