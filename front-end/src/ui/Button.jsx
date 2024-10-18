function Button({children ,type ="normal"  ,onClick}) {
  return (
    <button className={type ==="normal" ?styledNormalButton:styledCircleButton}
    onClick={onClick}>
    {children}
  </button>
  )
}
const styledNormalButton =`mt-6 px-2 py-2  bg-peach text-pink rounded-md shadow hover:bg-basic transition duration-300 ` ;

const styledCircleButton ='bg-peach ml-3 mt-3  rounded-full hover:Scale(50%) text-center p-3 text-sm';
export default Button
