import { useQuery } from "@tanstack/react-query";
import { getTotalPages } from "../../services/apiCakes";
import { useParams } from "react-router-dom";
import Loader from "../common/Loader";

function Pagination() {
    const { categoryId } = useParams(); // Get categoryId from URL

    const { data: pagesNum, error, isLoading } = useQuery({
        queryKey: ["pagesNum", categoryId],
        queryFn: () => getTotalPages(categoryId),
    });


    if (isLoading) return <Loader/>;
    if (error) return <div>Error loading pages: {error.message}</div>;

    // Ensure pagesNum has the expected structure
    if (!pagesNum || typeof pagesNum.totalPages === "undefined" || typeof pagesNum.totalRows === "undefined") {
        return <div>Error fetching page data</div>;
    }

    const { totalPages, totalRows } = pagesNum;
    console.log("totalPages:", totalPages, "totalRows:", totalRows);

  return (
    <div>
      <ul className={StyledContainer}>
        <li>
          <a href="#" className={StyledLink}>Prev</a>
        </li>
        {Array.from({ length: totalPages }, (_, index) => (
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
