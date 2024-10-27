import { createContext, useContext, useState } from "react";
import { useDeleteCake } from "../components/cakes/hooks/useDeleteCake";
import { useUpdateCake } from "../components/cakes/hooks/useUpdateCake";
import { useAddCake } from "../components/cakes/hooks/useAddCake";


const CakeContext = createContext();

function CakeProvider({ children }) {
  const [pageNumber, setPageNumber] = useState(1);
  const { deleteCakeObject } = useDeleteCake();
  const { addCake: addNewCake } = useAddCake();
  const {updateCake}=useUpdateCake();
  
  function handleAddCake(cakeInfo){
    addNewCake(cakeInfo);
    setPageNumber((prevPageNumber) => (prevPageNumber + 1));
  }
  
  function handleUpdateCake(cakeInfo){
    updateCake(cakeInfo);
  }

  function handleDeleteCake(id) {
    deleteCakeObject(id);
    setPageNumber((prevPageNumber) => (prevPageNumber - 1));
  }

  return (
    <CakeContext.Provider
      value={{handleAddCake,handleUpdateCake, handleDeleteCake, setPageNumber, pageNumber}}
    >
      {children}
    </CakeContext.Provider>
  );
}

function useCakeOperations() {
  const context = useContext(CakeContext);
  if (context === undefined) {
    throw new Error('useCakeOperations must be used within a CakeProvider');
  }
  return context;
}

export { CakeProvider, useCakeOperations };