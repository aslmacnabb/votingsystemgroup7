import { useEffect, useState } from "react";
import { getElection } from "../services/api";
import { useNavigate } from "react-router-dom";

export default function AdminDashboard() {
  const [ballots, setBallots] = useState([]);
  const [newBallotTitle, setNewBallotTitle] = useState("");
  const [newIssue, setNewIssue] = useState("");
  const [selectedBallot, setSelectedBallot] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    getElection().then(setBallots);
  }, []);

  const addBallot = () => {
    if (newBallotTitle.trim()) {
      const newBallot = {
        id: ballots.length + 1,
        title: newBallotTitle,
        options: []
      };
      setBallots([...ballots, newBallot]);
      setNewBallotTitle("");
    }
  };

  const addIssue = () => {
    if (newIssue.trim() && selectedBallot !== null) {
      const updatedBallots = ballots.map(b => {
        if (b.id === selectedBallot) {
          return {
            ...b,
            options: [...b.options, { id: b.options.length + 1, text: newIssue }]
          };
        }
        return b;
      });
      setBallots(updatedBallots);
      setNewIssue("");
    }
  };

  return (
    <div className="app-card">
      <h1>Admin Panel</h1>

      <div style={{ marginBottom: "20px" }}>
        <h3>Add New Ballot</h3>
        <input
          type="text"
          placeholder="Ballot Title"
          value={newBallotTitle}
          onChange={(e) => setNewBallotTitle(e.target.value)}
        />
        <button onClick={addBallot}>Add Ballot</button>
      </div>

      <div style={{ marginBottom: "20px" }}>
        <h3>Add Issue to Ballot</h3>
        <select onChange={(e) => setSelectedBallot(Number(e.target.value))}>
          <option value="">Select Ballot</option>
          {ballots.map(b => (
            <option key={b.id} value={b.id}>{b.title}</option>
          ))}
        </select>
        <input
          type="text"
          placeholder="Issue Text"
          value={newIssue}
          onChange={(e) => setNewIssue(e.target.value)}
        />
        <button onClick={addIssue}>Add Issue</button>
      </div>

      <h3>Existing Ballots</h3>
      {ballots.map((b) => (
        <div key={b.id} onClick={() => navigate(`/admin/ballot/${b.id}`)} style={{ cursor: "pointer", padding: "10px", border: "1px solid #ddd", marginBottom: "10px" }}>
          <strong>{b.title}</strong>
          <div>Issues: {b.options.length}</div>
        </div>
      ))}
    </div>
  );
}