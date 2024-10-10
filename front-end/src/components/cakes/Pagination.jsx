import { useQuery } from "@tanstack/react-query";
import { getTotalPages } from "../../services/apiCakes";
import { useParams } from "react-router-dom";

function Pagination() {
  //const { categoryId } = useParams(); // Get the categoryId from the URL
  //console.log("Category ID from URL:", categoryId); // Log for debugging
  const Id=4;
  // Use a unique queryKey for fetching total pages
  //const { data: pagesNum, error, isLoading } = useQuery({
  //  ["totalPages", Id], // Changed the queryKey to avoid conflict with cakes data
    //() => {
      //console.log("Calling getTotalPages with categoryId:", Id);
      //return getTotalPages(Id);
   // },
  //});
  const { data:pagesNum, error } = useQuery(['totalPages', Id], () => getTotalPages(Id));
  // Log the response for debugging
  console.log("pagesNum from query:", pagesNum);

  // Loading state
  //if (isLoading) return <div>Loading pages...</div>;

  // Error state
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
