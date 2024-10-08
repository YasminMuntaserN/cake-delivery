import Logo from './Logo';
import { NavLink } from "react-router-dom";
const nav__links = [
  {
    display: "Home",
    path: "/home",
  },
  {
    display: "Cakes",
    path: "/cakes",
  },
  {
    display: "Cart",
    path: "/cart",
  },
  {
    display: "Contact",
    path: "/contact",
  },
];
function PageNav() {
  return(
<nav className="sticky top-0 left-0 bg-white z-[99999] shadow-[5px_5px_15px_-5px_#d7d6d6] animate-slideDown h-[100px] ">
  <div className="flex items-center justify-between mt-[-20px] px-4 sm:px-10">
    <div className="sm:w-[200px] flex justify-center sm:justify-start">
      <Logo />
    </div>

    <div className="flex items-center gap-6 sm:gap-10">
      {nav__links.map((item, index) => (
        <NavLink
          to={item.path}
          key={index}
          className={({ isActive }) =>
            `font-sans font-semibold text-[1rem] transition duration-300 
            ${isActive ? 'text-pink' : 'text-basic hover:text-pink'}`}
        >
          {item.display}
        </NavLink>
      ))}
    </div>

    <div className="flex items-center gap-6 sm:gap-10">
      <span className="relative">
        <i className="cursor-pointer">
          <img className="w-[40px]" src="./cart.png" alt="Cart" />
        </i>
        <span className="absolute top-[-5px] right-[-5px] bg-pink text-white w-[20px] h-[20px] rounded-full text-[0.8rem] font-medium flex items-center justify-center">
          0
        </span>
      </span>
      <i className="cursor-pointer">
        <img className="w-[40px]" src="./fast-delivery.png" alt="Delivery" />
      </i>
    </div>
  </div>
</nav>
)}

export default PageNav
