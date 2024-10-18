function CustomersFeedbacksItem({feedback}) {
  return (
       <div className={StyledContainer}>
            <h4 className={StyledText}>{feedback.customerName}</h4>
            <p className="text-[#3a474e] text-xl">{feedback.feedback}</p>
        </div>
  )
}
const StyledContainer ="flex flex-col items-center justify-between p-5"; 
const StyledText="text-3xl text-center tracking-wider text-pink  mb-10";
export default CustomersFeedbacksItem