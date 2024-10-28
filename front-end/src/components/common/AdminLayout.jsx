import { Outlet } from "react-router-dom"
import AdminPageNav from "../../ui/AdminPageNav"
import Stat from "../adminPanel/Stat";

function AdminLayout() {
  return (
    <div className={StyledContainer}>
        <AdminPageNav />
      <main className={StyledMain}>
        <Stat />
        <Outlet/>
      </main>
    </div>
  )
}
const StyledContainer ="grid grid-cols-[15rem_1fr]";
const StyledMain ="pr-10 bg-gray-50 h-screen overflow-y-auto";

export default AdminLayout
