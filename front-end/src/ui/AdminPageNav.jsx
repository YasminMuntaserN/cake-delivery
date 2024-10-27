import { NavLink } from "react-router-dom"
import Logo from "./Logo"

function AdminPageNav() {
  return (
<nav className={StyledNav}>
  <div className={StyledLogoContainer}>
        <div className={StyledLogo}>
          <Logo />
        </div>

        <div className="flex items-center gap-6 sm:gap-10">
            <NavLink to="/home" className={StyledLink}>
              go to the site 🚀
            </NavLink>
        </div>
  </div>
</nav>
  )
}
const StyledNav ="sticky top-0 left-0 bg-white z-[99999] shadow-[5px_5px_15px_-5px_#d7d6d6] animate-slideDown h-[100px] ";
const StyledLogoContainer ="flex items-center justify-between mt-[-20px] pt-0 px-4 sm:px-10";
const StyledLogo ="sm:w-[200px] mt-[-20px] flex justify-center sm:justify-start";
const StyledLink ="text-peach text-2xl font-bold font-sansSerif hover:text-pink transition duration-300 ";
export default AdminPageNav