import { Outlet } from "react-router-dom";
import PageNav from "../PageNav"

function AppLayout() {

  return (
    <div className ="grid grid-rows-[auto_1fr_auto] h-screen ">
      <PageNav />
      <main>
      <Outlet/>
      </main>
      </div>
  )
}

export default AppLayout