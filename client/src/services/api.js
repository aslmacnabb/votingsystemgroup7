const API_BASE = "http://localhost:5136/api";

// Authentication
export async function login(username, password) {
  const response = await fetch(`${API_BASE}/user/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username, password })
  });
  return response.json();
}

// Elections
export async function getElection(electionId) {
  const response = await fetch(`${API_BASE}/ballot/election/${electionId}`);
  return response.json();
}

export async function getElections() {
  const response = await fetch(`${API_BASE}/ballot/elections`);
  return response.json();
}

// Voting
export async function submitVote(votes, username, password, electionId) {
  const response = await fetch(`${API_BASE}/ballot/submit`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username, password, electionId, votes })
  });
  return response.json();
}

export async function getUserBallots(username, password) {
  const response = await fetch(`${API_BASE}/ballot/history?username=${username}&password=${password}`);
  return response.json();
}

// Admin ballot status
export async function getAdminBallotStatus(electionId, username, password) {
  const response = await fetch(
    `${API_BASE}/admin/election/${electionId}/voterstatus?username=${encodeURIComponent(username)}&password=${encodeURIComponent(password)}`
  );
  return response.json();
}

