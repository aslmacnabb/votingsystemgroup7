import { useEffect, useState } from "react";
import { getAdminBallotStatus, getUserBallots, getElection } from "../services/api";
import "../styles/BallotHistory.css";

export default function AdminBallotView() {
  const [voters, setVoters] = useState([]);
  const [allBallots, setAllBallots] = useState([]);
  const [elections, setElections] = useState([]);

  useEffect(() => {
    getAdminBallotStatus().then(setVoters);
    getUserBallots().then(setAllBallots); 
    getElection().then(setElections);
  }, []);

  const getElectionDetails = (electionId) => {
    return elections.find(e => e.id === electionId);
  };

  const groupedBallots = allBallots.reduce((acc, ballot) => {
    if (!acc[ballot.username]) {
      acc[ballot.username] = [];
    }
    acc[ballot.username].push(ballot);
    return acc;
  }, {});

  return (
    <div className="app-card">
      <h1>Voting Status</h1>

      <div style={{ marginBottom: "30px" }}>
        <h3>Voter Status</h3>
        {voters.map((v) => (
          <div key={v.username}>
            {v.username} — {v.voted ? "✔ Voted" : "❌ Not Voted"}
          </div>
        ))}
      </div>

      <h3>All Ballots by User</h3>
      <div className="history-container">
        <div className="ballot-scroll-container">
          {Object.entries(groupedBallots).map(([username, userBallots]) => (
            <div key={username} className="ballot-details">
              <h4>User: {username}</h4>
              {userBallots.map((b) => (
                <div key={b.id}>
                  <p><strong>Ballot #{b.id} - {new Date().toLocaleDateString()}</strong></p>
                  {b.votes.map((v) => {
                    const election = getElectionDetails(v.electionId);
                    return (
                      <div key={v.electionId} style={{ marginLeft: "20px" }}>
                        <p><strong>{election?.title}:</strong> {getOptionText(v.electionId, v.optionId)}</p>
                      </div>
                    );
                  })}
                </div>
              ))}
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}