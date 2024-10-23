import { Link } from "react-router-dom";
import ContactLinks from "./ContactLinks";
import QuickLinks from "./QuickLinks";
import GetInTouch from "./GetInTouch";

const Footer = () => {
  return (
    <div className={StyledContainer}>
    <div className={StyledFirstBox}>
        <div className={StyledOverviewBox}>
            <Link to="/home">
                <h1 className={StyledShopName}>
                    <img src="./logo.png" alt="logo" className={StyledLogo}/>SweetCake
                </h1>
            </Link>
            <p className=" text-gray-700 mt-[-10px] mb-5">
            we believe that every celebration deserves a centerpiece as sweet and memorable as the moment itself. Whether it's birthdays, weddings, anniversaries, or any special occasion, we deliver freshly baked, hand-crafted cakes right to your doorstep! 🏡✨
            </p>
      </div>
    </div>

          <div className="lg:w-2/3 md:w-1/2">
              <div className="flex flex-wrap gx-5">
                  <GetInTouch/>
                  <QuickLinks/>
                  <ContactLinks />
              </div>
          </div>
      </div>
  );
};

const StyledContainer ="flex flex-wrap p-5 bg-gray-300 ";
const StyledFirstBox="w-1/4  flex flex-col items-center justify-center text-center mx-10 mt-[-100px] bg-pink rounded-lg  p-3" ;
const StyledOverviewBox=" p-3 rounded-lg border-4 border-white" ;
const StyledShopName="ml-[-50px] text-uppercase text-white text-3xl";
const StyledLogo ="w-1/2 h-full inline-block";

export default Footer;
