import { useForm } from "react-hook-form";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Button from "../../ui/Button";
import { useAddCake } from "./hooks/useAddCake";
import CategorySelector from "../common/CategorySelector";
import { useUpdateCake } from "./hooks/useUpdateCake";
import { useEffect } from "react";
import { useCakeOperations } from "../../context/CakeContext";


function AddEditCakeForm({cake}) {
  const { register, handleSubmit, formState ,setValue }=useForm();
  // if there is cake is not null then  the EditSession be will true else it will be false
  const isEditSession = Boolean(cake);
  const { errors } = formState;
  const { handleAddCake ,handleUpdateCake }=useCakeOperations();

  const onSubmit = (data) => {
    console.log(data);
    if (data) {
      const cakeData = {
        cakeName: data.name,
        description: data.description,
        price: data.price,
        stockQuantity:  data.stockQuantity,
        categoryID: data.categoryId,
        imageUrl:isEditSession ?cake.imageUrl : data.image[0].name,
    };
      if(!isEditSession){
        handleAddCake(cakeData);
        }
        else{
          handleUpdateCake({cakeID :cake.cakeID ,...cakeData});
      }
    }
  }

  function onError(errors) { 
    console.log(errors);
}

useEffect(() => {
  if (isEditSession && cake) {
    setValue("name", cake.cakeName);
    setValue("description", cake.description);
    setValue("price", cake.price);
    setValue("stockQuantity", cake.stockQuantity);
    setValue("categoryId", cake.categoryID);
  }
}, [cake, isEditSession, setValue]);

  return (
    <Form onSubmit={handleSubmit(onSubmit, onError)}>
      {isEditSession && cake.imageUrl && (
        <img src={cake.imageUrl} alt="Current Cake" className={StyledImage} />
      )}
      <FormRow label="Cake Name" error={errors?.name?.message}>
      <input
          className={StyledInput}
          type="text"
          id="name"
          {...register("name", {
              required: "This field is required"
          })} />
      </FormRow>
      
      <FormRow label="Description" error={errors?.description?.message}>
      <input
        className={StyledInput}
          type="text"
          id="description"
          {...register("description", {
              required: "This field is required"
          })} />
      </FormRow>

      <FormRow label="Price" error={errors?.price?.message}>
      <input
          className={StyledInput}
          type="number"
          id="price"
          {...register("price", {
              required: "This field is required"
          })} />
      </FormRow>

      <FormRow label="Stock Quantity" error={errors?.stockQuantity?.message}>
      <input
          className={StyledInput}
          type="number"
          id="stockQuantity"
          {...register("stockQuantity", {
              required: "This field is required"
          })} />
      </FormRow>

      <FormRow label="Category type">
        <CategorySelector register={register}/>
      </FormRow>

      <FormRow label="Cake photo">
        <input
            type= "file"
            className={StyledInput}
            id="imageUrl"
            accept="image/*"
            {...register("image",{required: isEditSession ? false : "This field is required"
            })} />
        </FormRow>

      <Button type="submit" onClick={handleSubmit(onSubmit, onError)}>Save</Button>
      </Form>
  )
}
const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-10 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
const StyledImage= "w-[200px] h-[150px] object-cover mb-5 flex ml-[100px]";
export default AddEditCakeForm
