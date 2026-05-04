import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getElection, getAdminBallotStatus } from "../services/api";
import { useAuth } from "../context/AuthContext";
import "../styles/BallotHistory.css";

export default function AdminBallotView() {
  const { id } = useParams();
  const navigate = useNavigate();
  const { user } = useAuth();
  const [election, setElection] = useState(null);
  const [voterStatus, setVoterStatus] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    if (!user || user.role !== "admin") {
      navigate("/");
      return;
    }

    const loadElection = async () => {
      try {
        const data = await getElection(id);
        if (data && data.electionId) {
          setElection(data);
        } else if (data && data.message) {
          setError(data.message);
          return;
        }

        if (user && user.role === "admin") {
          const statusData = await getAdminBallotStatus(id, user.username, user.password);
          if (Array.isArray(statusData)) {
            setVoterStatus(statusData);
          } else if (statusData && statusData.message) {
            setError(statusData.message);
          }
        }
      } catch (err) {
        setError("Failed to load election details");
        console.error(err);
      }
    };

    if (id) {
      loadElection();
    }
  }, [id, user, navigate]);

  if (error) {
    return (
      <div className="app-card">
        <h1>Error</h1>
        <p>{error}</p>
        <button onClick={() => navigate("/admin")}>Back to Admin</button>
      </div>
    );
  }

  if (!election) {
    return (
      <div className="app-card">
        <h1>Loading...</h1>
      </div>
    );
  }

  return (
    <div className="app-card">
      <h1>{election.electionName}</h1>
      <p>{election.description}</p>

      <div className="history-container">
        <h3>Offices</h3>
        {election.offices && election.offices.length > 0 ? (
          election.offices.map((office) => (
            <div key={office.officeId} style={{ padding: "10px", borderBottom: "1px solid #ccc", marginBottom: "10px" }}>
              <h4>{office.officeTitle}</h4>
              <p>{office.description}</p>
              <h5>Candidates:</h5>
              {office.candidates && office.candidates.length > 0 ? (
                <ul>
                  {office.candidates.map((candidate) => (
                    <li key={candidate.candidateId}>
                      {candidate.firstName} {candidate.lastName}
                      {candidate.partyAffiliation && <span> ({candidate.partyAffiliation})</span>}
                    </li>
                  ))}
                </ul>
              ) : (
                <p>No candidates</p>
              )}
            </div>
          ))
        ) : (
          <p>No offices</p>
        )}

        <h3>Measures</h3>
        {election.measures && election.measures.length > 0 ? (
          election.measures.map((measure) => (
            <div key={measure.measureId} style={{ padding: "10px", borderBottom: "1px solid #ccc", marginBottom: "10px" }}>
              <h4>{measure.measureTitle}</h4>
              <p>{measure.measureText}</p>
              <p><strong>Yes:</strong> {measure.yesDescription}</p>
              <p><strong>No:</strong> {measure.noDescription}</p>
            </div>
          ))
        ) : (
          <p>No measures</p>
        )}
      </div>

      <div className="history-container" style={{ marginTop: "30px" }}>
        <h3>Voter Participation</h3>
        {voterStatus && voterStatus.length > 0 ? (
          <table style={{ width: "100%", borderCollapse: "collapse" }}>
            <thead>
              <tr>
                <th style={{ borderBottom: "1px solid #ccc", textAlign: "left", padding: "8px" }}>Username</th>
                <th style={{ borderBottom: "1px solid #ccc", textAlign: "left", padding: "8px" }}>Name</th>
                <th style={{ borderBottom: "1px solid #ccc", textAlign: "left", padding: "8px" }}>Voted</th>
                <th style={{ borderBottom: "1px solid #ccc", textAlign: "left", padding: "8px" }}>Cast At</th>
              </tr>
            </thead>
            <tbody>
              {voterStatus.map((voter) => (
                <tr key={voter.username}>
                  <td style={{ borderBottom: "1px solid #eee", padding: "8px" }}>{voter.username}</td>
                  <td style={{ borderBottom: "1px solid #eee", padding: "8px" }}>
                    {voter.firstName} {voter.lastName}
                  </td>
                  <td style={{ borderBottom: "1px solid #eee", padding: "8px" }}>
                    {voter.hasVoted ? "Yes" : "No"}
                  </td>
                  <td style={{ borderBottom: "1px solid #eee", padding: "8px" }}>
                    {voter.castAt ? new Date(voter.castAt).toLocaleString() : "-"}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : (
          <p>No voter participation data available.</p>
        )}
      </div>

      <button onClick={() => navigate("/admin")} style={{ marginTop: "20px" }}>
        Back to Admin
      </button>
    </div>
  );
}