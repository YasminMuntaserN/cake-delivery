import { useSelector } from "react-redux"
import { getCustomer, getCustomerId } from "../customer/customerSlice"
import { useForm } from "react-hook-form";
import Button from "../../ui/Button";
import Form from "../../ui/Form";
import StartRating from "../../ui/StartRating";
import { useState } from "react";
import { useAddCustomersFeedback } from "./customersFeedbackshook/useAddCustomerFeedback";

function CustomerFeedbackForm() {
  const { register, handleSubmit ,formState} = useForm();
  const { isAdding, addCustomerFeedback ,id:customerFeedbackId }=useAddCustomersFeedback();
  const { errors } = formState;
  const customer =useSelector(getCustomer);
  const customerId =useSelector(getCustomerId);


  console.log(customer);
  console.log(`customerId: ${customerId}`);

  const { id, firstName, lastName } = customer;
  const [rating ,setRating]=useState(0);

  console.log(rating);
  function onError(errors) {
    console.log(errors);
}
const onSubmit = (data) => {
  const customerFeedback = {
    customerID: customerId,
    feedback: data.feedback,
    feedbackDate: new Date(),
    rating: rating
  };

  const payload = {
    newFeedbackDto: customerFeedback  // Wrap it as newFeedbackDto
  };

  addCustomerFeedback(JSON.stringify(payload));
};

  return (
    <div>

      <Form onSubmit={handleSubmit(onSubmit,onError)}>
      <p className={StyledText}>Thanks <span>{firstName}  {lastName}</span> to help us ❤️</p>

      <textarea
          className={StyledInput}
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
