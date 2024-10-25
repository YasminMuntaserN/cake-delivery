import Stat from "../components/adminPanel/Stat"
import StockQuantity from "../components/adminPanel/StockQuantity"
import WeeklySalesChart from "../components/adminPanel/WeeklySalesChart"

function Admin() {
  return (
    <>
      <Stat />
    <div className ={StyledContainer}>
      <StockQuantity />
      <WeeklySalesChart />
    </div>
    </>
  )
}

const StyledContainer = "grid grid-cols-[1fr_1fr] gap-10 items-center mt-[-10px]"

export default Admin
