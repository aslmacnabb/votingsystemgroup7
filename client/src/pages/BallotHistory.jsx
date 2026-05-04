import { useEffect, useState } from "react";
import { getUserBallots } from "../services/api";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import "../styles/BallotHistory.css";

export default function BallotHistory() {
  const [votes, setVotes] = useState([]);
  const [error, setError] = useState(null);
  const { user } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (!user) {
      navigate("/");
      return;
    }

    const loadVotes = async () => {
      try {
        const data = await getUserBallots(user.username, user.password);
        if (Array.isArray(data)) {
          setVotes(data);
        } else if (data && data.message) {
          setError(data.message);
        }
      } catch (err) {
        setError("Failed to load voting history");
        console.error(err);
      }
    };

    loadVotes();
  }, [user, navigate]);

  return (
    <div className="app-card">
      <h1>My Voting History</h1>
      {error && <p style={{ color: "red" }}>{error}</p>}
      
      <div className="history-container">
        {votes && votes.length > 0 ? (
          <div className="ballot-scroll-container">
            {votes.map((vote, index) => (
              <div key={vote.voteId || index} className="ballot-details">
                <p><strong>Election ID:</strong> {vote.electionId}</p>
                <p><strong>Vote ID:</strong> {vote.voteId}</p>
                {vote.candidateId && <p><strong>Candidate:</strong> {vote.candidateId}</p>}
                {vote.measureId && <p><strong>Measure:</strong> {vote.measureId}</p>}
                <p><strong>Selection:</strong> {vote.selectionValue}</p>
                <p><strong>Date:</strong> {new Date(vote.recordedAt).toLocaleString()}</p>
                <hr />
              </div>
            ))}
          </div>
        ) : (
          <p>No votes recorded yet</p>
        )}
      </div>
      
      <button onClick={() => navigate("/hub")} style={{ marginTop: "20px" }}>
        Back to Hub
      </button>
    </div>
  );
}