const BASE_URL = "http://localhost:5136/api";

export async function getElection() {
  return [
    {
      id: 1,
      title: "Mayor Election",
      options: [
        { id: 1, text: "yes" },
        { id: 2, text: "no" }
      ]
    },
    {
      id: 2,
      title: "President Election",
      options: [
        { id: 1, text: "yes" },
        { id: 2, text: "no" }
      ]
    }
  ];
}

export async function submitVote(vote) {
  console.log("Submitting vote:", vote);


  // return fetch(`${BASE_URL}/vote`, {
  //   method: "POST",
  //   headers: { "Content-Type": "application/json" },
  //   body: JSON.stringify(vote)
  // });
}
 
// for future reference, this is how we would fetch elections from the backend
 // return fetch(`${BASE_URL}/elections/1`).then(res => res.json());