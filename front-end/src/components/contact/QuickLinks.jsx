import { HiArrowSmallRight } from "react-icons/hi2";
import { Link } from "react-router-dom";

const links =[
  {href :"/home" , title:"Home"},
  {href :"/cart" , title:"Cart"},
  {href :"/cakes/-1" , title:"All Cakes"},
  {href :"/contact" , title:"Contact Us"},
]
function QuickLinks() {
  return (
<div className="lg:w-1/3 md:w-full pt-0 pt-lg-5 mb-5">
                      <h4 className={StyledHeader}>Quick Links</h4>
                      <div className={StyledContainer}>
                        {
                          links.map((link) => ( <Link key={link.title} className={StyledLink} to={link.href}>
                            <HiArrowSmallRight className={StyledIcon} />{link.title} </Link>))
                        }
                      </div>
                  </div>
  )
}
const StyledHeader ="text-lg md:text-xl text-pink font-semibold uppercase mb-6";
const StyledContainer ="flex flex-col justify-start";
const StyledIcon ="text-xl text-gray-600 ";
const StyledLink ="flex gap-3  m-2 ";



export default QuickLinks
