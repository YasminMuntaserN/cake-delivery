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
  const address = `${addressObj.locality},${addressObj.city},${addressObj.countryName}`;

  return { address, position };
});

const initialState={
  id:0,
  firstName: '',
  lastName: '',
  email: '',
  phoneNumber: '',
  postalCode:'',
  position: {},
  address: '',
};

const customerSlice = createSlice({
  name: 'user',
  initialState,
  reducers:{
    AddCustomer(state, action){
        const { id, firstName, lastName, email, phoneNumber, address, postalCode } = action.payload;
      console.log(` ${ id}, ${firstName},${ lastName}, ${email}, ${phoneNumber}, ${address}, ${postalCode }`);
        return { ...state, id, firstName, lastName, email, phoneNumber, postalCode, address };
    },
    UpdateCustomerId(state, action){
      //action.payload will be the id
      console.log(`action.payload: ${JSON.stringify(action.payload)}`);
        const { id} = action.payload;
        return { ...state, id};
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchAddress.fulfilled, (state, action) => {
      state.position = action.payload.position;
      state.address = action.payload.address;
    });
  },
});
export const {
  AddCustomer ,UpdateCustomerId
} = customerSlice.actions;

export default customerSlice.reducer;


export const getCustomer =(state)=>state.customer;
export const getCustomerId =(state)=>state.customer.id;
