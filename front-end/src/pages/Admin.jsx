import WeeklySalesChart from "../components/adminPanel/WeeklySalesChart";

function Admin() {
  return (
    <>
    <div className ={StyledContainer}>
      {/* <StockQuantity /> */}
      <WeeklySalesChart />
    </div>
    </>
  )
}

const StyledContainer = " ml-10 items-center mt-10"

export default Admin
