import Button from "../../ui/Button"

function Sizes({handleSetSize}) {
  return (
    <div className="StyledContainer">
      <Button type="Circle" onClick={()=>handleSetSize(1)}>
      🤌 Small
      </Button>
      <Button type="Circle" onClick={()=>handleSetSize(2)}>
      🫳 medium
      </Button>
      <Button type="Circle" onClick={()=>handleSetSize(3)}>
      🫴 large
      </Button>
    </div>
  )
}
const StyledContainer ="flex flex-col items-center justify-between mt-100";
export default Sizes
