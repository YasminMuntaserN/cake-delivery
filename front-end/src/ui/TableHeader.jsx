function TableHeader({gridColumns ,children}) {
  const styledTableHeader = ` grid  ${gridColumns} text-sm tracking-[0.4px]
gap- [2.4rem] items-center bg-grey-50 border-b order-grey-100  uppercase  text-grey-600 p-[10px_20px] `;
  return (
    <header role="row" className={styledTableHeader}>
        {children}
    </header>
  )
}

export default TableHeader
//