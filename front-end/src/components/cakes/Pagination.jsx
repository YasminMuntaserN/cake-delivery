import { useQuery } from "@tanstack/react-query";
import { getTotalPages } from "../../services/apiCakes";
import { useParams } from "react-router-dom";
import Loader from "../common/Loader";
import Error from "../common/Error";

function Pagination() {
    const { categoryId } = useParams(); // Get categoryId from URL

    const { data: pagesNum, error, isLoading } = useQuery({
        queryKey: ["pagesNum", categoryId],
        queryFn: () => getTotalPages(categoryId),
    });

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
