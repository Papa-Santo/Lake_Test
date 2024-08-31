import { ReactNode } from "react";
import Modal from "react-bootstrap/Modal";

interface I_ModalProps {
  show: boolean;
  setShow: Function;
  title: string;
  children: ReactNode;
}

function ModalDisplay(props: I_ModalProps) {
  return (
    <Modal
      show={props.show}
      onHide={() => props.setShow(false)}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          {props.title}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>{props.children}</Modal.Body>
    </Modal>
  );
}

export default ModalDisplay;
