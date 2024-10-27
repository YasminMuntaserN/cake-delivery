import { useForm } from "react-hook-form";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Button from "../../ui/Button";
import { useAddCategory } from "./hook/useAddCategory";
import { useUpdateCategory } from "./hook/useUpdateCategory";
import { useEffect } from "react";

function AddEditCategoryForm({ category}) {
  const { register, handleSubmit, formState ,setValue }=useForm();
  const isEditSession = Boolean(category);
  console.log(isEditSession);

  const { errors } = formState;
  const { addCategory }= useAddCategory();
  const {updateCategory}=useUpdateCategory();

  const onSubmit = (data) => {
    console.log(data);
    if (data) {
        const categoryData = {
          categoryName: data.name,
          categoryImageURL:isEditSession?category.categoryImageUrl : data.image[0].name,
        };
        if(!isEditSession){
        console.log(categoryData);
        addCategory(categoryData);
        }else{
          updateCategory({categoryID: category.categoryID ,...categoryData});
        }
      }
    }

  function onError(errors) { 
    console.log(errors);
  }

  useEffect(() => {
    if (isEditSession && category) {
      setValue("name", category.categoryName);
    }
  }, [category, isEditSession, setValue]);

  return (
    <Form onSubmit={handleSubmit(onSubmit, onError)}>
          <FormRow label="Category Name" error={errors?.name?.message}>
          <input
              className={StyledInput}
              type="text"
              id="name"
              {...register("name", {
                  required: "This field is required"
              })} />
          </FormRow>

          <FormRow label="Category photo">
            <input
                type= "file"
                className={StyledInput}
                id="imageUrl"
                accept="image/*"
                {...register("image",{required: isEditSession ? false : "This field is required"
                })} />
            </FormRow>
          <Button type="Save" onClick={handleSubmit(onSubmit, onError)}>Save</Button>
          <Button type="Cancel">Cancel</Button>
      </Form>
  )
}
const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-10 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";


export default AddEditCategoryForm;
