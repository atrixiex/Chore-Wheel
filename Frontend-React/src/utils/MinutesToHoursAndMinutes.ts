export default function MinutesToHoursAndMinutes(minutes: number): string {
  if (minutes < 60) {
    return `${minutes} minutes`;
  }

  const restMinutes = minutes % 60;
  const hours = Math.floor(minutes / 60);
  const multipleHours = hours > 1 ? true : false;

  return `${hours} hour${multipleHours ? "s" : ""} and ${restMinutes} minutes`;
}
