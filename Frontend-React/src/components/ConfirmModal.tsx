import type { Dispatch, SetStateAction } from "react";
import Modal from "./Modal";
import Button from "./Button";

interface ConfirmModalProps {
  setShowModal: Dispatch<SetStateAction<boolean>>;
  showModal: boolean;
}


export default function ConfirmModal({ setShowModal,
  showModal }: ConfirmModalProps) {



  return (

    <Modal isOpen={showModal} onClose={() => setShowModal(false)} title='Are you sure?'>
      <div className="mb-5">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Adipisci molestias natus perferendis consequuntur! Officia, nostrum? Itaque veniam rem, quidem dolorem quia numquam cumque, consequatur possimus illo asperiores quam dolore ad.
      </div>
      <div>
        <Button full onClick={() => setShowModal(false)}>Confirm</Button>
      </div>

    </Modal>
  );
}