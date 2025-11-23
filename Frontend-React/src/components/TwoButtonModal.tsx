import type { Dispatch, SetStateAction } from "react";
import Modal from "./Modal";
import Button from "./Button";

interface TwoButtonModalProps {
  setShowModal: Dispatch<SetStateAction<boolean>>;
  showModal: boolean;
}


export default function TwoButtonModal({ setShowModal,
  showModal }: TwoButtonModalProps) {



  return (

    <Modal isOpen={showModal} onClose={() => setShowModal(false)} title='Are you sure?'>
      <div className="mb-5">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Adipisci molestias natus perferendis consequuntur! Officia, nostrum? Itaque veniam rem, quidem dolorem quia numquam cumque, consequatur possimus illo asperiores quam dolore ad.
      </div>
      <div className="flex gap-5  ">
        <Button full color="primary"
          onClick={() => setShowModal(false)}>Confirm</Button>
        <Button full color="danger" size="md" >Deny</Button>
      </div>

    </Modal>
  );
}