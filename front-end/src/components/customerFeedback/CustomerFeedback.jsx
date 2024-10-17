import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';
import Loader from "../common/Loader";
import Error from "../common/Error";
import CustomersFeedbacksHeader from "./CustomersFeedbacksHeader";
import CustomersFeedbacksItem from "./CustomersFeedbacksItem";
import { useCustomersFeedback } from './customersFeedbackshook/useCustomersFeedback';


function CustomerFeedback() {

  const settings = {
    dots: true,
    infinite: true,
    speed: 100,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
  };

  const {Feedbacks ,error ,isLoading}= useCustomersFeedback();
  if (isLoading) return  <Loader />;
  
  if (error) return <Error/>;

  
  return (
  <div className={StyledContainer}>
        <div className={StyledSubContainer}>
        <CustomersFeedbacksHeader/>
            <Slider {...settings}>
          { Feedbacks.map((feedback)=><CustomersFeedbacksItem key={feedback.feedbackID} feedback={feedback}/>)}
            </Slider>
        </div>

        <div className={StyledImgContainer}>
            <img className={StyledImg} src="./Social-tree-cuate.png"/>
          </div >
  </div>
  )
}
const StyledContainer = "flex flex-col lg:flex-row items-center justify-between px-20 bg-gray-100 h-[500px]";
const StyledSubContainer="w-[600px] flex flex-col justify-between gap-10 mt-[-80px]";
const StyledImgContainer = "w-1/3 rounded-full overflow-hidden"; 
const StyledImg = "w-full object-cover transition-transform duration-1000 h-62";
export default CustomerFeedback

