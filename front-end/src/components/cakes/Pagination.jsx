import Loader from "../common/Loader";
import Error from "../common/Error";
import { usePagination } from "./hooks/usePagination";
import { HiArrowRightCircle ,HiArrowLeftCircle} from "react-icons/hi2";


function Pagination({ categoryId = -1, pageNumber, OnPageNumber }) {
  const {pagesNum , error, isLoading } = usePagination({ categoryId });
  if (isLoading) return <Loader />;
  if (error) return <Error />;
  const {totalPages} =pagesNum;

  return (
      <div>
          <ul className={StyledContainer}>
              <li>
                { (pageNumber > 1) && <button 
                      className={StyledLink} 
                      onClick={()=>OnPageNumber(pageNumber - 1)} 
                      disabled={pageNumber === 1}
                  >
                      <HiArrowLeftCircle />
                  </button>
                  }
                  { (pageNumber < totalPages) && <button 
                      className={StyledLink} 
                      onClick={()=>OnPageNumber(pageNumber + 1)} 
                      disabled={pageNumber === totalPages}
                  >
                      <HiArrowRightCircle />
                  </button>
                  }
              </li>
          </ul>
      </div>
  );
}

export default Pagination;


const StyledContainer ="flex space-x-2 mb-4 justify-center ";
const StyledLink ="text-pink px-3 py-1 rounded hover:text-peach text-4xl";


