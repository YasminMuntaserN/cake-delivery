function Table({children}) {
  return (
    <div role="table" className={styledTable}>
      {children}
    </div>
  )
}
const styledTable = " lg:mx-[60px] sm:mx-[30px] mt-10 border border-grey-200 text-[1.1rem] bg-grey-0 rounded-[7px] overflow-hidden p-5";

export default Table
