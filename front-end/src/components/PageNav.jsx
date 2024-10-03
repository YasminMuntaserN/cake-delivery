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
  return (
    <nav>
        <div className=" flex align-items-center justify- 
            content-between">
          <Logo/>
        </div>

        <div className="flex align-items-center gap-5">
            {nav__links.map((item, index) => (
              <NavLink
                to={item.path}
                key={index}
                className={(navClass) =>
                  navClass.isActive ? "active__menu" : ""
                }
              >
                {item.display}
              </NavLink>
            ))}
      </div>
    </nav>
  )
}

export default PageNav
