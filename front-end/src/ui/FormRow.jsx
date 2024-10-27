
function FormRow({label="",error, children}) {
  return (
    <div className={StyledContainer}>
      {label &&<label htmlFor={children.props.id}> {label}</label>}
      {children}
      {error&&
        <span className={StyledError}>
         {error}
          </span>}
    </div>
  )
}
const StyledContainer ="flex justify-between flex-nowrap mb-5";
const StyledError =" ml-10  text-red-700";

export default FormRow

