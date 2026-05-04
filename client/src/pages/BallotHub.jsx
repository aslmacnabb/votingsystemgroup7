import { useEffect, useState } from "react";
import { getElections } from "../services/api";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import "../styles/Hub.css";

export default function BallotHub() {
  const [elections, setElections] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const { user, logout } = useAuth();

  useEffect(() => {
    if (!user) {
      navigate("/");
      return;
    }

    const loadElections = async () => {
      try {
        const data = await getElections();
        if (Array.isArray(data)) {
          setElections(data);
        } else if (data && data.message) {
          setError(data.message);
        }
      } catch (err) {
        setError("Failed to load elections");
        console.error(err);
      }
    };

    loadElections();
  }, [user, navigate]);

  const handleLogout = () => {
    logout();
    navigate("/");
  };

  return (
    <div className="app-card">
      <h1>Election Hub</h1>
      <p>Welcome, {user?.username}!</p>
      {error && <p style={{ color: "red" }}>{error}</p>}

      <div className="scroll-wheel">
        {elections && elections.length > 0 ? (
          elections.map((election) => (
            <div
              key={election.electionId}
              className="wheel-item"
              onClick={() => navigate(`/ballot/${election.electionId}`)}
              style={{ cursor: "pointer" }}
            >
              <strong>{election.electionName}</strong>
              {election.description && <p>{election.description}</p>}
            </div>
          ))
        ) : (
          <p>No elections available</p>
        )}
      </div>

      <div style={{ marginTop: "20px" }}>
        <button onClick={() => navigate("/history")} style={{ marginRight: "10px" }}>
          View Voting History
        </button>
        <button onClick={handleLogout} style={{ backgroundColor: "#f44336", color: "white" }}>
          Logout
        </button>
      </div>
    </div>
  );
}