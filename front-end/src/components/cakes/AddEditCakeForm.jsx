import { useForm } from "react-hook-form";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Button from "../../ui/Button";
import CategorySelector from "../common/CategorySelector";
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
      const formData = new FormData();
          formData.append("CakeName", data.name);
          formData.append("Description", data.description);
          formData.append("Price", data.price);
          formData.append("StockQuantity", data.stockQuantity);
          formData.append("CategoryID", data.categoryId);

      
          if (!isEditSession) {
            if (data.photo && data.photo.length > 0) {
                formData.append("photo", data.photo[0]); 
            } else {
                console.error("No photo selected"); 
            }
            handleAddCake(formData);  
        } else {
            if (cake && cake.cakeID) {
              console.log( cake.cakeID);
                formData.append("CakeID", cake.cakeID);
                if (data.photo && data.photo.length > 0) {
                    formData.append("photo", data.photo[0]); 
                } else {
                    formData.append("ImageUrl", cake.imageUrl); 
                }
                handleUpdateCake({cakeInfo: formData,cakeID: cake.cakeID}); 
            } else {
                console.error("No valid cake ID found"); 
            }
          }
    }
};

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
        (!(cake.imageUrl.includes("/uploads/cakes"))?
          <img src={cake.imageUrl} alt={cake.cakeName} className={StyledImage} />
          :
          <img src={`https://localhost:7085${cake.imageUrl}`} alt={cake.cakeName} className={StyledImage} />
      )
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
        type="file"
        className={StyledInput}
        id="photo" 
        accept="image/*"
        {...register("photo", {
          required: isEditSession ? false : "This field is required"
        })} 
      />
    </FormRow>

      <Button type="submit" onClick={handleSubmit(onSubmit, onError)}>Save</Button>
      </Form>
  )
}
const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-10 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
const StyledImage= "w-[200px] h-[150px] object-cover mb-5 flex ml-[100px]";
export default AddEditCakeForm
