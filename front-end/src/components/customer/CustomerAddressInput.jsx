import React, { useEffect, useState } from "react";
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

  useEffect(()=>handleGeolocation ,[]);

  return (
    <div className="relative">
      <FormRow error={errors?.address?.message}>
        <input
          className={StyledInput}
          placeholder="Address"
          type="text"
          readOnly={true}
          value={address}
          id="address"
          {...register("address", {
            required: "This field is required",
          })}
        />
      </FormRow>
    </div>
  );
}

export default CustomerAddressInput;

