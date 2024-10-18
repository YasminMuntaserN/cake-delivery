function Button({children ,type ="Normal"  ,onClick}) {
  const styleClassName =type === "Normal" ?
  styledNormalButton: type === "Circle" ?
  styledCircleButton :type === "Delete" ?styledDeleteButton :styledCancelButton;
  return (
    <button className={styleClassName}
    onClick={onClick}>
    {children}
  </button>
  )
}

const styledNormalButton = `mt-6 px-2 py-2 bg-peach text-pink rounded-md shadow hover:bg-basic transition duration-300`;
const styledCircleButton = `bg-peach ml-3 mt-3 rounded-full hover:scale-50 text-center p-3 text-sm`;
const styledDeleteButton = `mt-6 px-3 py-3 bg-peach text-white rounded-md transition duration-300 ml-3`;
const styledCancelButton = `mt-6 px-2 py-2 bg-white border-2 border-gray-500 text-gray-500 rounded-md transition duration-300 ml-3`;

export default Button
