import { cloneElement, createContext, useContext, useState } from "react";
import { createPortal } from "react-dom";
import { HiXMark } from "react-icons/hi2";

const ModalContext = createContext();

function Modal({ children }) {
  const [openName, setOpenName] = useState("");

  const close = () => setOpenName("");
  const open = setOpenName;

  return (
    <ModalContext.Provider value={{ openName, close, open }}>
      {children}
    </ModalContext.Provider>
  );
}

function Open({ children, opens: opensWindowName, onClick }) {
  const { open } = useContext(ModalContext);

  const handleClick = () => {
    if (onClick) onClick();  
    open(opensWindowName); 
  };

  return cloneElement(children, { onClick: handleClick });
}

function Window({ children, name ,type }) {
  const { openName, close } = useContext(ModalContext);

  if (name !== openName) return null;

  return (
    <div className={Overlay}>
      <div className={(type === "List"? StyledListModal: StyledNormalModal)} >
        <button onClick={close} className={StyledButton}>
          <HiXMark />
        </button>

        <div>{cloneElement(children, { onCloseModal: close })}</div>
      </div>
    </div>
  );
}
const Overlay =`fixed top-0 left-0 w-full h-screen bg-backdrop-color backdrop-blur-md z-1000 transition-all duration-500`;
const StyledListModal ="  fixed overflow-y-auto right-0 w-1/4  bg-[rgba(255, 255, 255, 0.9)] rounded-lg shadow-lg pt-20 transition-all duration-500";
const StyledNormalModal ="fixed top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 bg-gray-100 rounded-lg shadow-lg p-8 transition-all duration-500";
const StyledButton ="bg-peach rounded-full border-none p-[0.4rem] absolute top-[1.2rem] right-[1.9rem] transition-all duration-500"
Modal.Open = Open;
Modal.Window = Window;
export default Modal
