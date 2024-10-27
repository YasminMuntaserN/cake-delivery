import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { Provider } from "react-redux";
import store from "./store"; 
import App from './App.jsx';
import './index.css';
import { Toaster } from 'react-hot-toast';
import { CartItemsProvider } from './context/CartItemsContext.jsx';
import { CakeProvider } from "./context/CakeContext";
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';


const queryClient = new QueryClient();

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Provider store={store}>
      <Toaster
        position="top-center"
        gutter={12}
        containerStyle={{ marginTop: "100px" }}
        toastOptions={{
          success: {
            duration: 3000,
          },
          error: {
            duration: 5000,
          },
          style: {
            fontSize: '16px',
            maxWidth: '500px',
            padding: '16px 24px',
            backgroundColor: "black",
            color: "pink",
          }
        }}
      />
      <CartItemsProvider>
        <QueryClientProvider client={queryClient}>
          <CakeProvider>
            <App />
          </CakeProvider>
        </QueryClientProvider>
      </CartItemsProvider>
    </Provider>
  </StrictMode>,
);