import Category from "../components/Categories/Category";
import CustomerFeedback from "../components/customerFeedback/CustomerFeedback";
import StarterSection from "../components/cakes/StarterSection";
import Footer from "../components/contact/Footer";


function Home() {
  return (
    <>
    <StarterSection/>
    <Category /> 
    <CustomerFeedback/>
    <Footer/>
    </>
  )
}

export default Home;
