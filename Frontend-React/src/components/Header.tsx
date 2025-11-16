import { Link } from "@tanstack/react-router"
import Cog from "../assets/CogOutline.svg"

export default function Header() {

  return (
    <nav className="flex justify-between py-8 px-4">
      <Link to="/">
        <h1 className="text-4xl font-bold">Chore Wheel</h1>
      </Link>
      <Link to="/profile">
        <img src={Cog} alt="Cog" />
      </Link>
    </nav>
  )
}