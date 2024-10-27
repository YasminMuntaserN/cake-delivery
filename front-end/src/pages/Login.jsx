import { useForm } from "react-hook-form";
import AdminPageNav from "../ui/AdminPageNav"
import Button from "../ui/Button"
import Form from "../ui/Form"
import FormRow from "../ui/FormRow"

function Login() {
  const { register, handleSubmit,formState }=useForm();
  const { errors } = formState;
  function onError(errors) { 
    console.log(errors);
}
function onSubmit(data) { 
  console.log(data);
}
  return (
    <>
    <AdminPageNav />

    <main className="mt-20 flex justify-center">
      <Form onSubmit={handleSubmit(onSubmit,onError )}>
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
const StyledInput = "w-1/2 bg-transparent p-1 w-[300px] border rounded-md  border-red-200 ml-10 outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
export default Login
