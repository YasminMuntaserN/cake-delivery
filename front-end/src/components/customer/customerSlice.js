import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getAddress } from "../../services/apiGeocoding";

// Get the user's current geolocation
function getPosition() {
  return new Promise((resolve, reject) => {
    navigator.geolocation.getCurrentPosition(resolve, reject);
  });
}

// Fetch the address based on geolocation
export const fetchAddress = createAsyncThunk('user/fetchAddress', async () => {
  const positionObj = await getPosition();
  const position = {
    latitude: positionObj.coords.latitude,
    longitude: positionObj.coords.longitude,
  };

  // Reverse geocoding
  const addressObj = await getAddress(position);
  const address = `${addressObj.locality}, ${addressObj.city}, ${addressObj.postcode}, ${addressObj.countryName}`;

  return { address, position };
});

const initialState={
  customerId:0,
  firstName: '',
  lastName: '',
  email: '',
  phone: '',
  position: {},
  address: '',
};

const customerSlice = createSlice({
  name: 'user',
  initialState,
  reducers:{
    setCustomerInfo(state, action){
      console.log(`action.payload: ${action.payload}`);
      // here the payload will be an object of customer info
      const {firstName ,lastName,email,phone ,address} = action.payload;
      return { ...state,firstName ,lastName ,email,phone,address};
    },
    setCustomerId(state, action){
      // here the payload will be an object of customer id
      return { ...state, customerId :action.payload };
    }
  },
  extraReducers: (builder) => {
    builder.addCase(fetchAddress.fulfilled, (state, action) => {
      state.position = action.payload.position;
      state.address = action.payload.address;
    });
  },
});
export const {
  setCustomerInfo,setCustomerId 
} = customerSlice.actions;

export default customerSlice.reducer;
