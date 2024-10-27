import { NavLink } from "react-router-dom"
import Logo from "./Logo";
import {
  HiOutlineCalendarDays,
  HiOutlineCog6Tooth,
  HiOutlineHome,
  HiOutlineHomeModern,
  HiOutlineUsers,
} from "react-icons/hi2";

const pages=[
  {
    to:"/admin",
    icon:<HiOutlineHome />,
    name:"Dashboard"
  },
  {
    to:"/adminCakes",
    icon:<HiOutlineCalendarDays />,
    name:"Cakes"
  },
  {
    to:"/adminCategories",
    icon:<HiOutlineHomeModern />,
    name:"Categories"
  },
  {
    to:"/adminCustomers",
    icon:<HiOutlineUsers />,
    name:"Customers"
  },
  {
    to:"/adminUsers",
    icon:<HiOutlineCog6Tooth />,
    name:"Users"
  }

];
function AdminPageNav() {
  return (
    <nav className="bg-gray-300 h-full">
      <Logo />
      <ul className={StyledList}>
{     pages.map((page)=>(
        <li>
          <NavLink className={({ isActive }) =>`flex pl-10 items-center gap-3 text-gray-800 text-base font-[20px] py-3 px-6 transition-all duration-300  hover:text-pink hover:bg-peach ${isActive &&'text-pink bg-gray-50'}`}
            to={page.to}>
            {page.icon}
            <span>{page.name}</span>
          </NavLink>
        </li>
))}
      </ul>
    </nav>
  );
}
const StyledList ="flex  flex-col gap-10";

export default AdminPageNav