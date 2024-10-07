import AppLayout from "./components/common/AppLayout";
import { BrowserRouter,  Navigate, Route,Routes } from "react-router-dom";
import Home from "./pages/Home";
import Cakes from "./pages/Cakes";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

function App() {
  return (
  <QueryClientProvider client={queryClient}>
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
  </QueryClientProvider>
  );

}


export default App

