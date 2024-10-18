import Loader from "../common/Loader";
import Error from "../common/Error";
import { usePagination } from "./cakeHooks/usePagination";

function Pagination() {
    const {pagesNum ,error, isLoading}=usePagination();

    if (isLoading) return <Loader />;
    if (error) return <Error />;


  return (
    <div>
      <ul className={StyledContainer}>
        <li>
          <a href="#" className={StyledLink}>Prev</a>
        </li>
              {Array.from({ length: pagesNum.totalPages }, (_, index) => (
          <li key={index + 1}>
            <a href="#" className={StyledLink}>
              {index + 1}
            </a>
          </li>
        ))}
        <li>
          <a href="#" className={StyledLink}>Next</a>
        </li>
      </ul>
    </div>
  );
}

export default Pagination;

const StyledContainer ="flex space-x-2 mb-4 justify-center mt-10";
const StyledLink ="bg-basic text-pink px-3 py-1 rounded hover:bg-peach";
