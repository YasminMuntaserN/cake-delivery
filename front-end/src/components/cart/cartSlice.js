import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  cart: [],
  /*cart :[
    cakeObject ,
    Quantity ,
    sizeId
  ]*/
};

const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    addItem(state, action) {
      //payload will be the cake object
      state.cart.push([action.payload ,1 ,1]);
    },
    setQuantity(state, action) {
      //payload will be the cake id and quantity
      const {id ,quantity}=action.payload;
      const cakeObject = state.cart.find(item => item[0].cakeID === id);
      cakeObject[1] = quantity;; 
    },
    deleteItem(state, action){
     //payload will be the cake id
    state.cart =state.cart.find(item => item[0].cakeID !==action.payload);
    }
  }
});

export const {
  addItem,setQuantity ,deleteItem
} = cartSlice.actions;

export default cartSlice.reducer;

export const getCart= (state)=> state.cart.cart;