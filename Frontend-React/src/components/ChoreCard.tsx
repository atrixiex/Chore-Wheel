import ChoreDifficultyToText from "../utils/ChoreDifficultyToText"
import MinutesToHoursAndMinutes from "../utils/MinutesToHoursAndMinutes"




export interface CardData {
  title: string,
  description: string,
  timeRequiredInMinutes: number,
  difficultyLevel: number
}

export interface CardProps {
  data: CardData
}



export default function ChoreCard({ data }: CardProps) {
  const { title, description, timeRequiredInMinutes, difficultyLevel } = data


  return (
    <section className="anonymous-pro-regular border-2 border-teal-800 px-8 py-5 text-md mb-5">
      <div className=" mb-2 text-3xl" >
        {title}
      </div>
      <div className="text-xl">Description:</div>
      <div className="mb-2">
        {description}
      </div>

      <div className="text-xl">
        Time Required:
      </div>
      <div className="mb-2">
        {MinutesToHoursAndMinutes(timeRequiredInMinutes)}
      </div>

      <div className="text-xl mb-2">
        Effort required: <span className={`${difficultyLevel > 3 ? "text-red-400" : "text-green-300"}`}>
          {ChoreDifficultyToText(difficultyLevel)}

        </span>
      </div>
    </section >
  )
}


