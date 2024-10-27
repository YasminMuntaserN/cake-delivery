import { NavLink } from "react-router-dom"
import Logo from "./Logo";
import {
  HiOutlineCalendarDays,
  HiOutlineCog6Tooth,
  HiOutlineHome,
  HiOutlineHomeModern,
  HiOutlineUsers,
} from "react-icons/hi2";

function AdminPageNav() {
  return (
    <nav className="bg-gray-300 h-full">
      <Logo />
      <ul className={StyledList}>
        <li>
          <NavLink className={StyledNavList} to="/admin">
            <HiOutlineHome />
            <span>Dashboard</span>
          </NavLink>
        </li>
        <li>
          <NavLink className={StyledNavList} to="/adminCakes">
            <HiOutlineCalendarDays />
            <span>Cakes</span>
          </NavLink>
        </li>
        <li>
          <NavLink className={StyledNavList} to="/adminCategories">
            <HiOutlineHomeModern />
            <span>Categories</span>
          </NavLink>
        </li>
        <li>
          <NavLink className={StyledNavList} to="/adminCustomers">
            <HiOutlineCog6Tooth />
            <span>Customers</span>
          </NavLink>
        </li>
        <li>
          <NavLink className={StyledNavList} to="/adminUsers">
            <HiOutlineUsers />
            <span>Users</span>
          </NavLink>
        </li>
      </ul>
    </nav>
  );
}
const StyledList ="flex  flex-col gap-10";
const StyledNavList ="flex pl-10 items-center gap-3 text-gray-800 text-base font-[20px] py-3 px-6 transition-all duration-300 rounded-lg hover:text-pink text-lg font-[600] hover:bg-peach";

export default AdminPageNav