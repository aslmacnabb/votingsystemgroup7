import { useEffect, useState } from "react";
import { getElection, submitVote } from "../services/api";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function Ballot() {
  const [elections, setElections] = useState([]);
  const [answers, setAnswers] = useState({});
  const [currentPage, setCurrentPage] = useState(0);
  const navigate = useNavigate();
  const { user } = useAuth();

  useEffect(() => {
    getElection().then(setElections);
  }, []);

  const currentElection = elections[currentPage];

  const handleNext = () => {
    if (currentPage < elections.length - 1) {
      setCurrentPage(currentPage + 1);
    }
  };

  const handlePrev = () => {
    if (currentPage > 0) {
      setCurrentPage(currentPage - 1);
    }
  };

  const handleSubmit = async () => {
    const votes = Object.entries(answers).map(([id, option]) => ({
      electionId: Number(id),
      optionId: option
    }));

    await submitVote(votes, user?.username);
    navigate("/history");
  };

  if (!currentElection) {
    return (
      <div className="app-card">
        <h1>Vote</h1>
        <p>No ballots available.</p>
      </div>
    );
  }

  return (
    <div className="app-card">
      <h1>Vote</h1>
      <div style={{ textAlign: "center" }}>
        <h2>{currentElection.title}</h2>
        {currentElection.options.map((o) => (
          <div key={o.id} style={{ margin: "20px 0" }}>
            <label>
              <input
                type="radio"
                name={currentElection.id}
                onChange={() =>
                  setAnswers({ ...answers, [currentElection.id]: o.id })
                }
                checked={answers[currentElection.id] === o.id}
              />
              {o.text}
            </label>
          </div>
        ))}
        <div style={{ marginTop: "30px" }}>
          <button onClick={handlePrev} disabled={currentPage === 0}>Previous</button>
          <span style={{ margin: "0 20px" }}>
            {currentPage + 1} of {elections.length}
          </span>
          <button onClick={handleNext} disabled={currentPage === elections.length - 1}>Next</button>
        </div>
        {currentPage === elections.length - 1 && (
          <button onClick={handleSubmit} style={{ marginTop: "20px" }}>Submit All Votes</button>
        )}
      </div>
    </div>
  );
}