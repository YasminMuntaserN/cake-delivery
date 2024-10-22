function PaymentOptions({handlePaymentMethod}) {
  return (
    <select className={StyledSelect} onChange={(e)=>handlePaymentMethod(e.target.value)}>
    <option value="Credit Card"> 💳 Credit Card </option>
    <option value="Bank Transfer"> 💸 Bank Transfer </option>
    <option value="Bank Transfer"> 🏧 PayPal  </option>
  </select> 
  )
}
const StyledSelect ="border-none outline-none mt-7 bg-gray-100 p-4 rounded-lg w-full";

export default PaymentOptions
