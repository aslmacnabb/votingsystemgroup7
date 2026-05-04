import { useEffect, useState } from "react";
import { getElections } from "../services/api";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function AdminDashboard() {
  const [elections, setElections] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const { user, logout } = useAuth();

  useEffect(() => {
    if (!user || user.role !== "admin") {
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
      <h1>Admin Dashboard</h1>
      <p>Welcome, Admin {user?.username}!</p>
      {error && <p style={{ color: "red" }}>{error}</p>}

      <div style={{ marginBottom: "20px" }}>
        <h2>Elections</h2>
        {elections && elections.length > 0 ? (
          <div>
            {elections.map((election) => (
              <div key={election.electionId} style={{ padding: "10px", border: "1px solid #ddd", marginBottom: "10px" }}>
                <h3>{election.electionName}</h3>
                <p>{election.description}</p>
                <p><strong>Offices:</strong> {election.offices?.length || 0}</p>
                <p><strong>Measures:</strong> {election.measures?.length || 0}</p>
                <button onClick={() => navigate(`/admin/ballot/${election.electionId}`)}>
                  View Details
                </button>
              </div>
            ))}
          </div>
        ) : (
          <p>No elections available</p>
        )}
      </div>

      <button onClick={handleLogout} style={{ backgroundColor: "#f44336", color: "white" }}>
        Logout
      </button>
    </div>
  );
}
