import { useForm } from "react-hook-form";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Button from "../../ui/Button";
import { useAddCategory } from "./hook/useAddCategory";

function AddCategoryForm() {
  const { register, handleSubmit, formState }=useForm();
  const { errors } = formState;
  const { addCategory }= useAddCategory();
  const onSubmit = (data) => {
    console.log(data);
    if (data) {
        const categoryData = {
          categoryName: data.name,
          categoryImageURL:data.image[0].name,
        };
        console.log(categoryData);
        addCategory(JSON.stringify(categoryData));
        }
    }

  function onError(errors) { 
    console.log(errors);
  }
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
                {...register("image",{required: "This field is required"
                })} />
            </FormRow>
          <Button type="Save" onClick={handleSubmit(onSubmit, onError)}>Save</Button>
          <Button type="Cancel">Cancel</Button>
      </Form>
  )
}
const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-10 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";


export default AddCategoryForm;
