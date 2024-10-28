import AppLayout from "./components/common/AppLayout";
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Cakes from "./pages/Cakes";
import Cart from "./pages/Cart";
import Checkout from "./pages/Checkout";
import Contact from "./pages/Contact";
import Admin from "./pages/Admin";
import Login from "./pages/Login";
import Customers from "./pages/Customers";
import Categories from "./pages/Categories";
import Users from "./pages/Users";
import AdminCakes from "./pages/AdminCakes";
import AdminLayout from "./components/common/AdminLayout";

const queryClient = new QueryClient({
    defaultOptions: {
        queries: {
            staleTime: 0,
        },
    },
});

function App() {
    return (
        <QueryClientProvider client={queryClient}>
            <ReactQueryDevtools initialIsOpen={true} />
            <BrowserRouter>
                <Routes>
                    <Route element={<AppLayout />}>
                        <Route index element={<Navigate replace to="home" />} />
                        <Route path="home" element={<Home />} />
                        <Route path="cakes/:categoryId" element={<Cakes />} />
                        <Route path="cart" element={<Cart />} />
                        <Route path="checkout" element={<Checkout />} />
                        <Route path="contact" element={<Contact />} />
                    </Route>
                    <Route path="login" element={<Login />} />
                    <Route element={<AdminLayout />}>
                        <Route path="admin" element={<Admin />} />
                        <Route path="adminCakes" element={<AdminCakes />} />
                        <Route path="adminCategories" element={<Categories />} />
                        <Route path="adminCustomers" element={<Customers />} />
                        <Route path="adminUsers" element={<Users />} />
                    </Route>
                    <Route path="*" element={<Navigate to="home" />} />
                </Routes>
            </BrowserRouter>
        </QueryClientProvider>
    );
}

export default App;



