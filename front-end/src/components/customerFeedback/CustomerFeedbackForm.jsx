import { useSelector } from "react-redux"
import { getCustomer} from "../customer/customerSlice"
import { useForm } from "react-hook-form";
import Button from "../../ui/Button";
import Form from "../../ui/Form";
import StartRating from "../../ui/StartRating";
import {useState } from "react";
import { useNavigate } from 'react-router-dom';
import { useAddCustomersFeedback } from "./customersFeedbackshook/useAddCustomerFeedback";
import { useCartItems } from "../../context/CartItemsContext";

function CustomerFeedbackForm() {
  const { register, handleSubmit } = useForm();
  const { addCustomerFeedback }=useAddCustomersFeedback();
  const customer =useSelector(getCustomer);
  const { id, firstName, lastName } = customer;
  const [rating ,setRating]=useState(0);
  const navigate =useNavigate();
  const {handleClear} =useCartItems();

  console.log(customer);
  console.log(rating);

  function onError(errors) {
    console.log(errors);
}
const onSubmit = (data) => {
  const feedbackData = {
    CustomerID: id, 
    Feedback: data.feedback, 
    FeedbackDate: new Date(),
    Rating: rating, 
  };
  addCustomerFeedback(feedbackData,{
    onSuccess:()=>{
      navigate("/home");
      handleClear();
    }
  });
};

  return (
    <div>
      <Form onSubmit={handleSubmit(onSubmit,onError)}>
      <p className={StyledText}>Thanks <span>{firstName}  {lastName}</span> to help us ❤️</p>

      <input
          className={StyledInput}
          type="text"
          id="feedback"
          placeholder="share with us your feedback"
          {...register("feedback", { required: "This field is required" })}
        />
        <StartRating onRating={setRating}/>
        <Button type="submit"> Save</Button>
      </Form> 
    </div>
  )
}
const StyledInput = "w-full bg-transparent py-5 px-5 border-0 border-b-2 border-custom-gray outline-none";
const StyledText ="text-xl text-basic mb-2";
export default CustomerFeedbackForm
