import { Outlet } from "react-router-dom"
import AdminPageNav from "../../ui/AdminPageNav"
import Stat from "../adminPanel/Stat";

function AdminLayout() {
  return (
    <div className={StyledContainer}>
        <AdminPageNav />
      <main className="pr-10 bg-gray-50">
        <Stat />
        <Outlet/>
      </main>
    </div>
  )
}
const StyledContainer ="grid grid-cols-[15rem_1fr] grid-rows-[auto_1fr] ";
export default AdminLayout
