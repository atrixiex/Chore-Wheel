import Cog from "../assets/CogOutline.svg"

export default function Header() {

  return (
    <div className="flex justify-between py-8 px-4">
      <h1 className="text-4xl font-bold">Chore Wheel</h1>

      {/* <Cog /> */}

      <img src={Cog} alt="properites" />
    </div>
  )
}