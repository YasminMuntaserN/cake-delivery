import AppLayout from "./components/common/AppLayout";
import { BrowserRouter, createBrowserRouter, Navigate, Route, RouterProvider, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Cakes from "./pages/Cakes";

const router =createBrowserRouter([
  {
    element : <AppLayout />,
    // errorElement : <Error />,
    children :[
  
  {
    path:'/',
    element: <Home/>
  },

//   {
//     path:'/menu',
//     element: <Menu/>,
//     loader :menuLoader,
//     errorElement : <Error />,
//   },
//   {
//     path:'/cart',
//     element: <Cart/>
//   },
//   {
//     path:'/order/new',
//     element: <CreateOrder/>,
//     action : createOrderAction
//   },
//   {
//     path:'/order/:orderId',
//     element: <Order/>,
//     loader:orderLoader
//   }
 ]
}] );

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route element={<AppLayout/>}>
          <Route index element={
                  <Navigate replace to="home"/>}/>
          <Route path="home" element={<Home />} />
          <Route path="cakes" element={<Cakes />} />
          </Route>
        {/* <Route path="login" element={<Login />} />
        <Route path="*" element={<PageNotFound />} /> */}
    </Routes>
</BrowserRouter>
  );

}


export default App

