

import { useState, type Dispatch, type SetStateAction } from "react";
import Modal from "./Modal";
import Button from "./Button";
import StyledInput from "./StyledInput";

interface NewChoreModalProps {
  setShowModal: Dispatch<SetStateAction<boolean>>;
  showModal: boolean;
}
export default function NewChoreModal({ setShowModal,
  showModal }: NewChoreModalProps) {

  const [error, setError] = useState('')
  const [isLoading, setIsLoading] = useState(false)

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setIsLoading(true)
    setError('')

    //   try {
    //     await auth.login(username, password)
    //   } catch (err) {
    //     setError('Invalid username or password')
    //   } finally {
    //     setIsLoading(false)
    //   }
  }

  return (

    <Modal isOpen={showModal} onClose={() => setShowModal(false)} title='Create New Chore'>
      <div className="mb-5 mx-5 text-purple-200">
        <form onSubmit={handleSubmit}
          className="flex flex-col gap-5"
        >
          <StyledInput
            id="title"
            label="Title"
            type="text"
            required
            autoComplete="off"
            className="border-purple-300"

          />

          <StyledInput
            id="description"
            label="Description"
            type="text"
            autoComplete="off"
          // className="border-green-600"

          />

          <StyledInput
            id="time"
            label="Estimated Time Required (minutes)"
            type="number"
            min="1"
            placeholder="5"
            autoComplete="off"

          />


        </form>
      </div>
      <div className="mx-5">
        <Button full
          // type="submit"
          // update logic here
          onClick={() => setShowModal(false)}>Confirm</Button>
      </div>

    </Modal>
  );
}


