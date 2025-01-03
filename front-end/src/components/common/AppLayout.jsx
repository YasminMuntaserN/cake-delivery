import { Outlet, useLocation } from "react-router-dom";
import PageNav from "../../ui/PageNav"
import VideoLayout from "../common/VideoLayout";


function AppLayout() {
  const location = useLocation();
  
  // Check if the current path is not the home page
  const showVideo = location.pathname !== '/home'  ; 
  return (

    <div className ={StyledCointainer}>
      <main>
      <PageNav />
              {showVideo && location.pathname.includes("/cakes") && <VideoLayout>All Cakes :</VideoLayout>}
              {showVideo && location.pathname.includes("/cart") && <VideoLayout>Your Cart</VideoLayout>}
              {showVideo && location.pathname.includes("/checkout") && <VideoLayout>checkout</VideoLayout>}
              {showVideo && location.pathname.includes("/contact") && <VideoLayout>Contact Us</VideoLayout>}
      <Outlet/>
      </main>
      </div>
  )
}

const StyledCointainer ="grid grid-rows-[auto_1fr_auto] h-screen ";
export default AppLayout