let ballots = [
  {
    id: 1,
    title: "Mayor Election",
    options: [
      { id: 1, text: "Issue 1" },
      { id: 2, text: "Issue 2" },
      { id: 3, text: "Issue 3" },
      { id: 4, text: "Issue 4" },
      { id: 5, text: "Issue 5" },
      { id: 6, text: "Issue 6" }
    ]
  },
  {
    id: 2,
    title: "City Council Election",
    options: [
      { id: 7, text: "Issue 7" },
      { id: 8, text: "Issue 8" },
      { id: 9, text: "Issue 9" },
      { id: 10, text: "Issue 10" },
      { id: 11, text: "Issue 11" },
      { id: 12, text: "Issue 12" }
    ]
  }
];

let userVotes = [
  {
    id: 1,
    username: "user",
    votes: [
      { electionId: 1, optionId: 1 },
      { electionId: 2, optionId: 7 }
    ]
  },
  {
    id: 2,
    username: "user2",
    votes: [
      { electionId: 1, optionId: 2 },
      { electionId: 2, optionId: 8 }
    ]
  }
];

export async function getElection() {
  return ballots;
}

export async function submitVote(votes, username = "user") {
  userVotes.push({
    id: userVotes.length + 1,
    username,
    votes
  });
}

export async function getUserBallots(username = "user") {
  return userVotes.filter(v => v.username === username);
}

let mockUsers = ["alice", "bob", "charlie", "user"];

export async function getAdminBallotStatus() {
  const votedUsers = [...new Set(userVotes.map(v => v.username))];
  return mockUsers.map(username => ({
    username,
    voted: votedUsers.includes(username)
  }));
}