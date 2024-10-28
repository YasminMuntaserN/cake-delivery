import { HiMiniUser } from "react-icons/hi2";
import { NavLink } from "react-router-dom";
import CartOverview from '../components/cart/CartOverview';
import Logo from './Logo';
const nav__links = [
  {
    display: "Home",
    path: "/home",
  },
  {
    display: "Cakes",
    path: "/cakes/-1",
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
<nav className={StyledNav}>
  <div className= {StyledContainer}>
    <div className={StyledLogoContainer}>
      <Logo />
    </div>

    <div className={StyledSide}>
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

    <div className={StyledSide}>
      <CartOverview />
      <NavLink className="cursor-pointer" to="/login">
            <HiMiniUser className="w-[2.5rem] h-[2.5rem] text-gray-300"/>
      </NavLink>
    </div>
  </div>
</nav>
)}

const StyledNav="sticky top-0 left-0 bg-white z-[99999] shadow-[5px_5px_15px_-5px_#d7d6d6] animate-slideDown";
const StyledContainer ="flex items-center justify-between mt-[-20px] px-4 sm:px-10";
const StyledLogoContainer ="sm:w-[200px] flex justify-center sm:justify-start";
const StyledSide ="flex items-center gap-6 sm:gap-10";
export default PageNav
