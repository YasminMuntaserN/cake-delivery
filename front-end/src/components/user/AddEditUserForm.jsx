import { useForm } from "react-hook-form";
import { useEffect } from "react";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Button from "../../ui/Button";
import { useAddUser } from "./hooks/useAddUser";
import { useUpdateUser } from "./hooks/useUpdateUser";


function AddEditUserForm({user ,operationName}) {
  const { register, handleSubmit, formState ,getValues,setValue }=useForm();
  // if there is user is not null then  the EditSession be will true else it will be false
  const isEditSession = Boolean(user);
  const { errors } = formState;
  const {addUser}=useAddUser();
  const{updateUser}=useUpdateUser();

  const onSubmit = (data) => {
    console.log(data);
    if (data) {
      const UserData = {
        email: data.email,
        password: data.password,
    };
      if(!isEditSession) addUser(UserData);
      else updateUser({userID :user.userID ,...UserData});
    }
  }
  
  function onError(errors) { 
    console.log(errors);
}

useEffect(() => {
  if (isEditSession && user) {
    if(operationName==="email"){
    setValue("password", user.password);
    setValue("confirmPassword", user.password);
    }else if(operationName ==="password"){
      setValue("email", user.email);
    }
  }
}, [user, isEditSession, setValue,operationName]);

  return (
    <Form onSubmit={handleSubmit(onSubmit, onError)}>
      <FormRow label="Email" error={errors?.email?.message}>
      <input
          className={StyledInput}
          disabled={operationName ==="password"}
          type="email"
          id="email"
          {...register("email", {
              required: "This field is required"
          })} />
      </FormRow>
      
      <FormRow label="Password" error={errors?.password?.message}>
      <input
        className={StyledInput}
          disabled={operationName ==="email"}
          type="password"
          id="password"
          {...register("password", {
              required: "This field is required",
              validate: (value) => value.length >= 8 || "Passwords must be at least 8 characters",
          })} />
      </FormRow>

      <FormRow label="Confirm Password" error={errors?.confirmPassword?.message}>
      <input
        className={StyledInput}
        disabled={operationName ==="email"}
        type="password"
        id="confirmPassword"
        {...register("confirmPassword", {
          required: "Please confirm your password",
          validate: (value) => value === getValues("password") || "Passwords do not match",
        })}
      />
      </FormRow>
      <Button type="submit" onClick={handleSubmit(onSubmit, onError)}>Save</Button>
      </Form>
  )
}

const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-10 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";

export default AddEditUserForm;
