import React, { createContext, useContext } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  IncQuantity as SetNewIncQuantity,
  DecQuantity as SetNewDecQuantity,
  setSize as SetNewSize,
  addItem,
  getCart,
  deleteItem,
  clearCart,
} from '../components/cart/cartSlice';

const CartItemsContext = createContext();

function CartItemsProvider({ children }) {
  const dispatch = useDispatch();
  const cart = useSelector(getCart);

  const handleAdd = (cake) => {
    dispatch(addItem(cake));
  };

  const handleInc = (id) => {
    dispatch(SetNewIncQuantity(id));
  };

  const handleDec = (id) => {
    dispatch(SetNewDecQuantity(id));
  };

  const handleSize = (id, sizeId) => {
    dispatch(SetNewSize({ id, sizeId }));
  };

  const handleDelete = (id) => {
    dispatch(deleteItem(id));
  };
  const handleClear = () => {
    dispatch(clearCart());
  };

  return (
    <CartItemsContext.Provider
      value={{ handleInc, handleDec, handleSize, handleAdd, handleDelete,handleClear, cart }}
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
