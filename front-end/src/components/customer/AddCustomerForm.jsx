import { useDispatch } from "react-redux";
import { useForm } from "react-hook-form";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import CustomerAddressInput from "./CustomerAddressInput";
import { setCustomerInfo } from "./customerSlice";

function AddCustomerForm({ onGeocode }) {
    const { register, handleSubmit, formState } = useForm();

    const { errors } = formState;
    const dispatch =useDispatch();

    const onSubmit = (data) => {
        console.log(`data :${data}`);
        dispatch(setCustomerInfo(data));
    };

    function onError(errors) {
        console.log(errors);
    }

    return (
        <Form onSubmit={()=>handleSubmit(onSubmit ,onError)}>
        <FormRow error={errors?.firstName?.message}>
            <input
            className={StyledInput}
            placeholder="First name"
            type="text"
            id="firstName"
            {...register("firstName", { required: "This field is required" })}
            />
        </FormRow>

        <FormRow error={errors?.lastName?.message}>
            <input
            className={StyledInput}
            placeholder="Last name"
            type="text"
            id="lastName"
            {...register("lastName", { required: "This field is required" })}
            />
        </FormRow>

        <FormRow error={errors?.email?.message}>
            <input
            className={StyledInput}
            placeholder="Email"
            type="email"
            id="email"
            {...register("email", { required: "This field is required" })}
            />
        </FormRow>

        <FormRow error={errors?.phone?.message}>
            <input
            className={StyledInput}
            placeholder="Phone"
            type="tel"
            id="phone"
            {...register("phone", { required: "This field is required" })}
            />
        </FormRow>

        <CustomerAddressInput errors={errors} register={register} StyledInput={StyledInput} onGeocode={onGeocode} />
        </Form>
    );
    }

    const StyledInput = "w-full bg-transparent py-2 px-5 border-0 border-b-2 border-custom-gray outline-none";

    export default AddCustomerForm;
