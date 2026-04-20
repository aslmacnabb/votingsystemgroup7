import { useEffect, useState } from "react";
import { getUserBallots, getElection } from "../services/api";
import { useAuth } from "../context/AuthContext";
import "../styles/BallotHistory.css";

export default function BallotHistory() {
  const [ballots, setBallots] = useState([]);
  const [elections, setElections] = useState([]);
  const { user } = useAuth();

  useEffect(() => {
    getUserBallots(user?.username).then(setBallots);
    getElection().then(setElections);
  }, [user]);

  const getElectionDetails = (electionId) => {
    return elections.find(e => e.id === electionId);
  };

  const getOptionText = (electionId, optionId) => {
    const election = getElectionDetails(electionId);
    const option = election?.options.find(o => o.id === optionId);
    return option?.text || "Unknown";
  };

  return (
    <div className="app-card">
      <h1>My Ballots</h1>
      <div className="history-container">
        <div className="ballot-scroll-container">
          {ballots.map((b) => (
            <div key={b.id} className="ballot-details">
              <h3>Ballot #{b.id}</h3>
              <p><strong>Date:</strong> {new Date().toLocaleDateString()}</p>
              {b.votes.map((v) => {
                const election = getElectionDetails(v.electionId);
                return (
                  <div key={v.electionId}>
                    <p><strong>{election?.title}:</strong> {getOptionText(v.electionId, v.optionId)}</p>
                  </div>
                );
              })}
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}