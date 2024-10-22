function Form({children ,onSubmit}) {
  return (
    <form className ={StyledForm} onSubmit={onSubmit}>
      {children}
    </form>
  )
}

const StyledForm ="mx-5 my-10 border-2 border-pink p-10 rounded-lg";

export default Form;
