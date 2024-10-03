import { Outlet } from "react-router-dom";
import PageNav from "../components/PageNav"
import Home from "./Home";

function AppLayout() {

  return (
    <div className ="grid grid-rows-[auto_1fr_auto] h-screen ">
      <PageNav />
      <Outlet/>
      {/* <Home/> */}
      </div>
  )
}

export default AppLayout