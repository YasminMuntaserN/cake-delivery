import CakeElement from "./CakeElement";
import Loader from "../common/Loader";
import Error from "../common/Error";
import { useGetTopCakes } from "./hooks/useTopCakes";

function TopCakes() {

    const {TopCakes,error , isLoading}=useGetTopCakes();
    if (isLoading) return <Loader />;
    if (error) return <Error />;

    return (
      <section className={StyledContainer}>
        <h2 className={StyledHeader}>The Fresh cakes 😋 </h2>
        <div className={styledSubContainer}>
            {TopCakes.map((cake) => (
                <CakeElement key={cake.cakeID} cake={cake} />
            ))}
        </div>
      </section>
    );
}
const styledSubContainer = "mt-10 flex justify-center flex-wrap gap-10 relative";
const StyledHeader ="text-4xl font-bold text-center text-basic font-sans ";
const StyledContainer ="mt-[-100px] pb-20 pt-10 bg-gray-100 rounded-lg";
export default TopCakes
