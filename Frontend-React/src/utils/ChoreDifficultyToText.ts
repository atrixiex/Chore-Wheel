export default function ChoreDifficultyToText(input: number): string {
  let response = "Invalid value";
  switch (input) {
    case 1:
      response = "None";
      break;
    case 2:
      response = "Tiny";
      break;
    case 3:
      response = "Meh";
      break;
    case 4:
      response = "Sigh";
      break;
    case 5:
      response = "Herculean";
      break;
  }
  return response;
}

// public enum ChoreDifficulty
// {
//     None = 1,
//     Tiny,
//     Meh,
//     Sigh,
//     Herculean
// }
