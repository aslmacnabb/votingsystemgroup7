import { useEffect, useState } from "react";
import { getElections, submitVote } from "../services/api";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import "../styles/Ballot.css";

export default function Ballot() {
  const [elections, setElections] = useState([]);
  const [answers, setAnswers] = useState({});
  const [currentElectionIndex, setCurrentElectionIndex] = useState(0);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const { user } = useAuth();

  useEffect(() => {
    if (!user) {
      navigate("/");
      return;
    }

    const loadElections = async () => {
      try {
        const data = await getElections();
        if (data && Array.isArray(data)) {
          setElections(data);
        } else if (data && data.message) {
          setError(data.message);
        } else {
          setElections([]);
        }
      } catch (err) {
        setError("Failed to load elections");
        console.error(err);
      }
    };

    loadElections();
  }, [user, navigate]);

  const currentElection = elections[currentElectionIndex];

  const handleNext = () => {
    if (currentElectionIndex < elections.length - 1) {
      setCurrentElectionIndex(currentElectionIndex + 1);
    }
  };

  const handlePrev = () => {
    if (currentElectionIndex > 0) {
      setCurrentElectionIndex(currentElectionIndex - 1);
    }
  };

  const handleVoteChange = (itemId, value, type) => {
    setAnswers({
      ...answers,
      [`${currentElection.electionId}-${type}`]: { id: itemId, value }
    });
  };

  const handleSubmit = async () => {
    try {
      if (!user) {
        setError("User not authenticated");
        return;
      }

      const votes = [];
      Object.entries(answers).forEach(([key, vote]) => {
        const [electionId, type] = key.split("-");
        if (type === "candidate") {
          votes.push({
            candidateId: vote.id,
            officeId: null,
            measureId: null,
            selectionValue: vote.value
          });
        } else if (type === "measure") {
          votes.push({
            candidateId: null,
            officeId: null,
            measureId: vote.id,
            selectionValue: vote.value
          });
        }
      });

      if (votes.length === 0) {
        setError("Please make at least one selection");
        return;
      }

      
      const result = await submitVote(
        votes,
        user.username,
        user.password,
        currentElection.electionId
      );

      if (result && result.message) {
        navigate("/history");
      } else {
        setError(result?.message || "Failed to submit votes");
      }
    } catch (err) {
      setError("Error submitting votes: " + err.message);
      console.error(err);
    }
  };

  if (error) {
    return (
      <div className="app-card">
        <h1>Voting Error</h1>
        <p>{error}</p>
        <button onClick={() => navigate("/")}>Return to Login</button>
      </div>
    );
  }

  if (!currentElection) {
    return (
      <div className="app-card">
        <h1>Vote</h1>
        <p>No elections available at this time.</p>
        <button onClick={() => navigate("/hub")}>Back to Hub</button>
      </div>
    );
  }

  return (
    <div className="app-card">
      <h1>Vote - {currentElection.electionName}</h1>

      <div style={{ textAlign: "center", margin: "20px 0" }}>
        <h3>Offices</h3>
        {currentElection.offices && currentElection.offices.length > 0 ? (
          currentElection.offices.map((office) => (
            <div key={office.officeId} style={{ margin: "20px 0", borderBottom: "1px solid #ccc", paddingBottom: "15px" }}>
              <h4>{office.officeTitle}</h4>
              {office.description && <p>{office.description}</p>}
              {office.candidates && office.candidates.map((candidate) => (
                <div key={candidate.candidateId} style={{ margin: "10px 0" }}>
                  <label>
                    <input
                      type="radio"
                      name={`office-${office.officeId}`}
                      checked={answers[`${currentElection.electionId}-candidate`]?.id === candidate.candidateId}
                      onChange={() =>
                        handleVoteChange(
                          candidate.candidateId,
                          `${candidate.firstName} ${candidate.lastName}`,
                          "candidate"
                        )
                      }
                    />
                    {candidate.firstName} {candidate.lastName}
                    {candidate.partyAffiliation && <span> ({candidate.partyAffiliation})</span>}
                  </label>
                </div>
              ))}
            </div>
          ))
        ) : (
          <p>No offices in this election</p>
        )}

        <h3>Measures</h3>
        {currentElection.measures && currentElection.measures.length > 0 ? (
          currentElection.measures.map((measure) => (
            <div key={measure.measureId} style={{ margin: "20px 0", borderBottom: "1px solid #ccc", paddingBottom: "15px" }}>
              <h4>{measure.measureTitle}</h4>
              {measure.measureText && <p>{measure.measureText}</p>}
              <div style={{ margin: "10px 0" }}>
                <label>
                  <input
                    type="radio"
                    name={`measure-${measure.measureId}`}
                    checked={answers[`${currentElection.electionId}-measure`]?.id === measure.measureId && answers[`${currentElection.electionId}-measure`]?.value === "yes"}
                    onChange={() => handleVoteChange(measure.measureId, "yes", "measure")}
                  />
                  Yes {measure.yesDescription && <span>- {measure.yesDescription}</span>}
                </label>
              </div>
              <div style={{ margin: "10px 0" }}>
                <label>
                  <input
                    type="radio"
                    name={`measure-${measure.measureId}`}
                    checked={answers[`${currentElection.electionId}-measure`]?.id === measure.measureId && answers[`${currentElection.electionId}-measure`]?.value === "no"}
                    onChange={() => handleVoteChange(measure.measureId, "no", "measure")}
                  />
                  No {measure.noDescription && <span>- {measure.noDescription}</span>}
                </label>
              </div>
            </div>
          ))
        ) : (
          <p>No measures in this election</p>
        )}

        <div style={{ marginTop: "30px" }}>
          <button onClick={handlePrev} disabled={currentElectionIndex === 0}>
            Previous
          </button>
          <span style={{ margin: "0 20px" }}>
            {currentElectionIndex + 1} of {elections.length}
          </span>
          <button onClick={handleNext} disabled={currentElectionIndex === elections.length - 1}>
            Next
          </button>
        </div>
        {currentElectionIndex === elections.length - 1 && (
          <button
            onClick={handleSubmit}
            style={{ marginTop: "20px", padding: "10px 20px", backgroundColor: "#4CAF50", color: "white" }}
          >
            Submit All Votes
          </button>
        )}
      </div>
    </div>
  );
}
