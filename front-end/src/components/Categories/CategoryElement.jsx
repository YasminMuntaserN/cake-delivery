import {  NavLink } from "react-router-dom";

function CategoryElement({Category}) {
    return (
    <NavLink to={`/cakes/${Category.categoryID}`}>
      <div className={StyledContainer}>
            <div className={StyledSubContainer} >
              <img
                className="w-12 h-12 absolute top-[20%] left-[25%] "
                src={Category.categoryImageUrl}
                alt="category__item"
              />
            </div>
        <h6>{Category.categoryName}</h6>
      </div>
    </NavLink>
    );
}

export default CategoryElement

const StyledContainer ="w-[350px] p-7 flex items-center gap-3 bg-[#fde4e4]  rounded cursor-pointer transition duration-400 hover:shadow-lg hover:scale-110";


const StyledSubContainer = "bg-pink w-[100px] h-[100px] rounded-full relative mr-10";