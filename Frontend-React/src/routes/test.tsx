import { createFileRoute } from '@tanstack/react-router'
import ChoreCard, { type CardData, type CardProps } from '../components/ChoreCard'

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
  return <div>Hello "/test"!

    {cardTestData.map(data => <ChoreCard data={data} key={data.title}></ChoreCard>)}

  </div>
}


