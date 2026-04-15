import { useEffect, useState } from "react";
import { getElection, submitVote } from "../services/api";
import "./Ballot.css";

export default function Ballot() {
  const [elections, setElections] = useState([]);
  const [selected, setSelected] = useState({});

  useEffect(() => {
    getElection().then(data => setElections(data));
  }, []);

  const handleSelect = (electionId, optionId) => {
    setSelected(prev => ({
      ...prev,
      [electionId]: optionId
    }));
  };

  const handleSubmit = async () => {
    const votes = Object.entries(selected).map(([electionId, optionId]) => ({
      electionId: Number(electionId),
      optionId
    }));

    await submitVote(votes);
    alert("Votes submitted!");
  };

  if (!elections.length) return <p>Loading...</p>;

  return (
    <div className="ballot-container">
      <div className="ballot-card">
        <h1 className="ballot-title">Ballot</h1>

        {elections.map((election) => (
          <div key={election.id} className="ballot-section">
            <h2>{election.title}</h2>

            {election.options.map((o) => (
              <div
                key={o.id}
                className={`ballot-option ${
                  selected[election.id] === o.id ? "selected" : ""
                }`}
                onClick={() => handleSelect(election.id, o.id)}
              >
                <input
                  type="radio"
                  checked={selected[election.id] === o.id}
                  readOnly
                />
                {o.text}
              </div>
            ))}
          </div>
        ))}

        <button
          className="ballot-button"
          onClick={handleSubmit}
          disabled={
            elections.length !== Object.keys(selected).length
          }
        >
          Submit All Votes
        </button>
      </div>
    </div>
  );
}