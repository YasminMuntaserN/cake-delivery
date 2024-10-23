import { useDispatch } from "react-redux";
import { useForm } from "react-hook-form";
import Form from "../../ui/Form";
import Button  from "../../ui/Button";
import FormRow from "../../ui/FormRow";
import CustomerAddressInput from "./CustomerAddressInput";
import { AddCustomer, UpdateCustomerId } from "./customerSlice";
import {useCustomer} from "./hooks/useCustomer";
import { useEffect } from "react";

function AddCustomerForm({ onGeocode ,onShowOrder}) {
    const dispatch =useDispatch();
    const { register, handleSubmit, formState  } = useForm();
    const  {addCustomer} =useCustomer();
    const { errors } = formState;


    const onSubmit = (data) => {
        if (data) {
            const addressInfo = data.address ? data.address.split(",") : [];
            const customerData = {
                firstName: data.firstName,
                lastName: data.lastName,
                email: data.email,
                phoneNumber:  data.phoneNumber,
                address: addressInfo.at(0) || '',
                city: addressInfo.at(1)  || '',
                postalCode: data.postalCode,
                country: addressInfo.at(2)  || ''
            };

            addCustomer(JSON.stringify(customerData),{
                onSuccess :(data)=>{
                    const id= data.customerID;
                    console.log(`id ${id} after adding customer`);
                    dispatch(AddCustomer({id,...customerData }));
                    onShowOrder(true);
                }
            });
            }
        }

    function onError(errors) {
        console.log(errors);
    }
    return (
        <Form onSubmit={handleSubmit(onSubmit ,onError)}>
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
            type="text"
            id="email"
            {...register("email", { required: "This field is required" })}
            />
        </FormRow>

        <FormRow error={errors?.phoneNumber?.message}>
            <input
            className={StyledInput}
            placeholder="phone Number"
            type="Number"
            id="phoneNumber"
            {...register("phoneNumber", { required: "This field is required" })}
            />
        </FormRow>

        <FormRow error={errors?.postalCode?.message}>
            <input
            className={StyledInput}
            placeholder="postal Code"
            type="text"
            id="postalCode"
            {...register("postalCode", { required: "This field is required" })}
            />
        </FormRow>

        <CustomerAddressInput errors={errors} register={register} StyledInput={StyledInput} onGeocode={onGeocode} />

        <FormRow className="form-row">
        <Button type="submit" >Submit</Button>
        </FormRow>
        </Form>

    );
    }

    const StyledInput = "w-full bg-transparent py-2 px-5 border-0 border-b-2 border-custom-gray outline-none";

    export default AddCustomerForm;
