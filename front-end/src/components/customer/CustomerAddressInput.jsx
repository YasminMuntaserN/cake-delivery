import React, { useEffect } from "react";
import FormRow from "../../ui/FormRow";
import { useDispatch } from "react-redux";
import { fetchAddress } from "./customerSlice";

function CustomerAddressInput({ errors, register, StyledInput, onGeocode,setValue={setValue} }) {
  const dispatch = useDispatch();

  const handleGeolocation = async () => {
    try {
      const { address, position } = await dispatch(fetchAddress()).unwrap();
      
      onGeocode(position); 
      setValue("address", address); 
    } catch (error) {
      console.error("Error fetching position:", error);
    }
  };

  useEffect(() => {
    handleGeolocation(); 
  }, [handleGeolocation]);

  return (
    <div className="relative">
      <FormRow error={errors?.address?.message}>
        <input
          className={StyledInput}
          placeholder="Address"
          type="text"
          readOnly={true}
          id="address"
          {...register("address")}
        />
      </FormRow>
    </div>
  );
}

export default CustomerAddressInput;

