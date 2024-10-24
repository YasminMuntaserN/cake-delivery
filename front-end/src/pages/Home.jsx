import Category from "../components/Categories/Category";
import CustomerFeedback from "../components/customerFeedback/CustomerFeedback";
import StarterSection from "../components/cakes/StarterSection";
import Footer from "../components/contact/Footer";
import TopCakes from "../components/cakes/TopCakes";


function Home() {
  return (
    <>
    <StarterSection/>
    <Category /> 
    <TopCakes />
    <CustomerFeedback/>
    <Footer/>
    </>
  )
}

export default Home;
