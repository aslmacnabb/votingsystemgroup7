import { useEffect, useState } from "react";
import { getElection } from "../services/api";
import { useNavigate } from "react-router-dom";

export default function BallotHub() {
  const [ballots, setBallots] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    getElection().then(setBallots);
  }, []);

  return (
    <div className="app-card">
      <h1>Your Ballots</h1>

      <div className="scroll-wheel">
        {ballots.map((b) => (
          <div
            key={b.id}
            className="wheel-item"
            onClick={() => navigate(`/ballot/${b.id}`)}
          >
            {b.title}
          </div>
        ))}
      </div>
    </div>
  );
}