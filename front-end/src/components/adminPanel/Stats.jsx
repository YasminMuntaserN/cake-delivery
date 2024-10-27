function Stats({operation ,color}) {
const StyledStat=` w-full bg-${color} border border-gray-200 rounded-md p-5 m-10 flex items-center gap-5`;
  return (
    <div className={StyledStat}>
        {operation.icon}
        <h3 className={StyledHeader}>{operation.name}</h3>
    </div>
  )
}
const StyledHeader="self-end text-sm uppercase tracking-wide font-semibold text-gray-500 ";
export default Stats
