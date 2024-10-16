import {configureStore} from "@reduxjs/toolkit";
import cartReducer from "./components/cart/cartSlice";


const store =configureStore({
  reducer:{
    cart:cartReducer,
  }
})


export default store;