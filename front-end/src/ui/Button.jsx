function Button({children ,className ,onClick}) {
  return (
    <button className={`mt-6 px-2 py-2  bg-peach text-pink rounded-md shadow hover:bg-basic transition duration-300 ` +{className}}
    onClick={onClick}>
    {children}
  </button>
  )
}

export default Button
