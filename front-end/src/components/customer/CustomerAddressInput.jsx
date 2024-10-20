import React, { useState } from "react";
import FormRow from "../../ui/FormRow";
import { useDispatch } from "react-redux";
import { fetchAddress } from "./customerSlice";

function CustomerAddressInput({ errors, register, StyledInput, onGeocode }) {
  const dispatch = useDispatch();
  const [address , setAddress]=useState();

  const handleGeolocation = async () => {
    try {
      const { address, position } = await dispatch(fetchAddress()).unwrap();
      
      onGeocode(position); 
      setAddress(address);
    } catch (error) {
      console.error("Error fetching position:", error);
    }
  };
  console.log(address);

  return (
    <div className="relative">
      <FormRow error={errors?.address?.message}>
        <input
          className={StyledInput}
          placeholder="Address"
          type="text"
          disabled={false}
          value={address}
          id="address"
          {...register("address", {
            required: "This field is required",
          })}
        />
      </FormRow>
      <button
        type="button"
        onClick={handleGeolocation}
        className="absolute top-0 right-0 border-2 border-gray-200 p-2 rounded-md"
      >
        Get Your Position
      </button>
    </div>
  );
}

export default CustomerAddressInput;

