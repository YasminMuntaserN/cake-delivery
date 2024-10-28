import { useForm } from "react-hook-form";
import Button from "../ui/Button";
import Form from "../ui/Form";
import FormRow from "../ui/FormRow";
import { useNavigate } from "react-router-dom";
import Logo from "../ui/Logo";
import {useExistUser} from "../components/user/hooks/useExistUser";
import toast from "react-hot-toast";

function Login() {
  const { register, handleSubmit,formState }=useForm();
  const {existUser}=useExistUser();
  const { errors } = formState;
  const navigate =useNavigate();
  function onError(errors) { 
    console.log(errors);
}
function onSubmit(data) { 
  console.log(data);
  if(data){
    existUser(data ,{
      onSuccess: (data) => {
        console.log(data);
        if(data ) navigate("/admin")
          else  toast.error("Incorrect Password or Email🥲 ")
      }});
  }
}

  return (
    <>
    <main className="mt-20 flex justify-center">
      <Form onSubmit={handleSubmit(onSubmit,onError )}>
        <div className="flex justify-center mb-10" ><Logo /></div>
        <FormRow label="Email" error={errors?.email?.message}>
        <input
          className={StyledInput}
          type="Email"
          id="email"
          {...register("email", {
              required: "This field is required"
          })} />
        </FormRow>

        <FormRow label="Password" error={errors?.password?.message}>
        <input
          className={StyledInput}
          type="password"
          id="password"
          {...register("password", {
              required: "This field is required"
          })} />
        </FormRow>

        <div>
          <Button type="submit">Login</Button>
        </div>
      </Form>
    </main>
    </>
  )
}
const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-5 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
export default Login
