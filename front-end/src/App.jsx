import AppLayout from "./pages/AppLayout";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

const router =createBrowserRouter([
  {
    element : <AppLayout />,
    path:'/'
    // errorElement : <Error />,
//     children :[
  
//   {
//     path:'/',
//     element: <Home/>
//   },
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
// ]
}] );

function App() {
  return (
   <RouterProvider router={router}/>
  );

}


export default App

