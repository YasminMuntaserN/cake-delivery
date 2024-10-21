function FormRow({error, children}) {
  return (
    <div className={StyledContainer}>
      {/* {label &&<label htmlFor={children.props.id}> {label}</label>} */}
      {children}
      {error&& <span className="text-red">{error}</span>}
    </div>
  )
}
const StyledContainer ="mb-10";

export default FormRow
