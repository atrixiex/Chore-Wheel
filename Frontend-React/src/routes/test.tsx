import { createFileRoute } from '@tanstack/react-router'
import ChoreCard, { type CardData } from '../components/ChoreCard'
import Button from '../components/Button'
import { useState, type Dispatch, type SetStateAction } from 'react'
import Modal from '../components/Modal'
import ConfirmModal from '../components/ConfirmModal'
import TwoButtonModal from '../components/TwoButtonModal'
import NewChoreModal from '../components/NewChoreModal'

export const Route = createFileRoute('/test')({
  component: RouteComponent,
})


const cardTestData: CardData[] = [{
  title: "Ta ut sopor",
  description: "Ta ut soporna och stoppa i ny soppåse.",
  timeRequiredInMinutes: 10,
  difficultyLevel: 2
},
{
  title: "Tvätta fönster",
  description: "Tvätta minst 3 fönster.",
  timeRequiredInMinutes: 123,
  difficultyLevel: 4
},


]



function RouteComponent() {

  const [showModal, setShowModal] = useState(false);
  const [showModal2, setShowModal2] = useState(false);






  return <div>Hello "/test"!

    {cardTestData.map(data => <ChoreCard data={data} key={data.title}></ChoreCard>)}


    <Button
      full
      onClick={() => setShowModal(true)}
      color='primary' size='md'>Create new Chore</Button>
    <div className='mt-3'>


      <Button onClick={() => setShowModal2(true)
      }>
        Two button modal
      </Button>
    </div>



    <TwoButtonModal setShowModal={setShowModal2} showModal={showModal2}>

    </TwoButtonModal>

    <NewChoreModal

      setShowModal={setShowModal}
      showModal={showModal}
    />


  </div >
}






