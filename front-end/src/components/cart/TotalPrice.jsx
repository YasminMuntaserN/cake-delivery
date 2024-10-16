import Button from "../../ui/Button";

function TotalPrice() {
    return (
        <div className={styledContainer }>
            <p>Subtotal: 
            <span className="text-pink ">500 </span>
            </p>
            <div className={styledBtnContainer }>
            <Button>Order it now</Button>
                <Button>Continue Shopping</Button>
            </div>
        </div>
    );
}
const styledContainer = "mt-10 ml-20";
const styledBtnContainer = " flex flex-wrap gap-10";

export default TotalPrice;