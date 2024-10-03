import { Outlet } from "react-router-dom";
import PageNav from "../components/PageNav"

function AppLayout() {

  return (
    <div className ="grid grid-rows-[auto_1fr_auto] h-screen ">
      <PageNav />
      <Outlet/>
      </div>
  )
}

export default AppLayout