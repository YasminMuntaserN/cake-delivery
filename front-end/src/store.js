import {configureStore} from "@reduxjs/toolkit";
import cartReducer from "./components/cart/cartSlice";
import customerReducer from "./components/customer/customerSlice";



const store =configureStore({
  reducer:{
    cart:cartReducer,
    customer: customerReducer,
  }
})


export default store;