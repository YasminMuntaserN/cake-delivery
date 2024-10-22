import { HiChatBubbleBottomCenterText } from "react-icons/hi2";
import Button from "../../ui/Button";
import Modal from "../../ui/Modal";
import CustomerFeedbackForm from "./CustomerFeedbackForm";


function AddCustomerFeedback() {
  return (
    <Modal>
      <div className={StyledContainer}>
          <HiChatBubbleBottomCenterText className="text-5xl text-peach" />
          <p className={styledText}>"Your feedback helps us improve 🎉!<br/> How did you feel about your order?"</p>
        <Modal.Open>
          <Button type="submit">git it to us Now 🤩  </Button> 
        </Modal.Open>
      </div>

      <Modal.Window>
            <CustomerFeedbackForm/> 
      </Modal.Window>
    </Modal>
  )
}

const StyledContainer ="border-none outline-none my-10 bg-gray-100 p-5 rounded-lg w-full ";
const styledText ="text-sm text-basic my-5";

export default AddCustomerFeedback
