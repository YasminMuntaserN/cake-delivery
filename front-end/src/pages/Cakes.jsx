import CakesTable from "../components/cakes/CakesTable";
import Pagination from "../components/cakes/Pagination";
import SearchBar from "../components/common/SearchBar";

function Cakes() {
  
  return (
      <>
          <SearchBar/>
          <CakesTable />
          <Pagination />

    </>
  );
}

export default Cakes
