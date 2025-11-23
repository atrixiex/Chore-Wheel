import { createFileRoute } from '@tanstack/react-router'
import ChoreCard, { type CardData } from '../components/ChoreCard'
import Button from '../components/Button'
import { useState } from 'react'
import Modal from '../components/Modal'

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






  return <div>Hello "/test"!

    {cardTestData.map(data => <ChoreCard data={data} key={data.title}></ChoreCard>)}


    <Button
      onClick={() => setShowModal(true)}
      color='primary' size='md'>Modal</Button>

    <Modal isOpen={showModal} onClose={() => setShowModal(false)} title='hello'>Text</Modal>
  </div>
}


