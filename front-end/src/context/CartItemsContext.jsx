import React, { createContext, useContext } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  IncQuantity as SetNewIncQuantity,
  DecQuantity as SetNewDecQuantity,
  setSize as SetNewSize,
  addItem,
  getCart,
  deleteItem,
} from '../components/cart/cartSlice';

const CartItemsContext = createContext();

function CartItemsProvider({ children }) {
  const dispatch = useDispatch();
  const cart = useSelector(getCart);

  const handleAdd = (cake) => {
    console.log("handleAdd");
    dispatch(addItem(cake));
    console.log(`Added without quantity`);
  };

  const handleInc = (id) => {
    console.log(`handleInc ${id}`);
    dispatch(SetNewIncQuantity(id));
  };

  const handleDec = (id) => {
    console.log(`handleDec ${id}`);
    dispatch(SetNewDecQuantity(id));
  };

  const handleSize = (id, sizeId) => {
    dispatch(SetNewSize({ id, sizeId }));
  };

  const handleDelete = (id) => {
    console.log(`delete ${id}`);
    dispatch(deleteItem(id));
  };

  console.log(cart);

  return (
    <CartItemsContext.Provider
      value={{ handleInc, handleDec, handleSize, handleAdd, handleDelete, cart }}
    >
      {children}
    </CartItemsContext.Provider>
  );
}

function useCartItems() {
  const context = useContext(CartItemsContext);
  if (context === undefined) {
    throw new Error('useCartItems must be used within a CartItemsProvider');
  }
  return context;
}

export { CartItemsProvider, useCartItems };
