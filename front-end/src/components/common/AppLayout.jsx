import { Outlet, useLocation } from "react-router-dom";
import PageNav from "../../ui/PageNav"
import VideoLayout from "../common/VideoLayout";

function AppLayout() {
  const location = useLocation();
  
  // Check if the current path is not the home page
  const showVideo = location.pathname !== '/home'  ; 
  return (
    <div className ="grid grid-rows-[auto_1fr_auto] h-screen ">
      <PageNav />
      <main>
              {showVideo && location.pathname.includes("/cakes") && <VideoLayout>All Cakes :</VideoLayout>}
              {showVideo && location.pathname.includes("/cart") && <VideoLayout>Your Cart</VideoLayout>}
      <Outlet/>
      </main>
      </div>
  )
}

export default AppLayout