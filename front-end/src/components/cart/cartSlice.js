import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  cart: []
};

const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    addItem(state, action) {
      //payload will be the cake object
      state.cart.push(
        {cakeObject :action.payload ,quantity:1 ,sizeId:1}
      );
    },
    IncQuantity(state, action) {
      // payload will be the cake id
      const item = state.cart.find(item => item.cakeObject.cakeID === action.payload);
      console.log(`IncQuantity item ${item}`);
      if (item) {
        item.quantity =item.quantity+1; 
      }
    },DecQuantity(state, action) {
      // payload will be the cake id
      const item = state.cart.find(item => item.cakeObject.cakeID === action.payload);
    console.log(`handleInc item ${item}`);
      if (item && item.quantity > 1) {
        item.quantity =item.quantity-1; 
      } else {
        deleteItem(action.payload);
      }
    },
    deleteItem(state, action) {
      // payload will be the cake id
      state.cart = state.cart.filter(item => item.cakeObject.cakeID !== action.payload);
      console.log(`state.cart: ${state.cart}`);
    },
    setSize(state, action){
      // payload will be the cake id and sizeId
      const { id, sizeId } = action.payload;
      const item = state.cart.find(item => item.cakeObject.cakeID === id);
      if (item) {
        item.sizeId = sizeId; 
      }
    }
  }
});

export const {
  addItem,IncQuantity,DecQuantity ,deleteItem,setSize 
} = cartSlice.actions;

export default cartSlice.reducer;

export const getCart= (state)=> state.cart.cart;
export const getTotalPrice = (state) =>
  state.cart.cart.reduce((sum, item) => sum + item.cakeObject.price * item.quantity, 0);

