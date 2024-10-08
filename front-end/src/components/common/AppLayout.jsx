import { Outlet } from "react-router-dom";
import PageNav from "../PageNav"
import VideoLayout from "../common/VideoLayout";

function AppLayout() {

  return (
    <div className ="grid grid-rows-[auto_1fr_auto] h-screen ">
      <PageNav />
      <main>
        <VideoLayout />
      <Outlet/>
      </main>
      </div>
  )
}

export default AppLayout