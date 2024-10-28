import Modal from "../../ui/Modal";
import { HiOutlineEnvelope ,HiOutlineKey} from "react-icons/hi2";
import AddEditUserForm from "./AddEditUserForm";
;

function UpdateUser({operationName, user}) {
  return (
    <Modal>
      {
        operationName ==="email" && (
        <>
        <Modal.Open>
            <HiOutlineEnvelope className={StyledIcon}/>
          </Modal.Open>
          <Modal.Window>
              <AddEditUserForm operationName="email" user={user} />
          </Modal.Window>
          </>
        )
      }
      {
        operationName ==="password" && (
        <>
        <Modal.Open>
            <HiOutlineKey className={StyledIcon} />
          </Modal.Open>
          <Modal.Window>
              <AddEditUserForm operationName="password" user={user} />
          </Modal.Window>
          </>
        )
      }
    </Modal>
  )
  
}
const StyledIcon="h-5 w-5 ";
export default UpdateUser
