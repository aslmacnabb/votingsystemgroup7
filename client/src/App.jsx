import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Login from "./pages/Login";
import Ballot from "./pages/Ballot";
import BallotHistory from "./pages/BallotHistory";
import BallotHub from "./pages/BallotHub";
import AdminDashboard from "./pages/AdminDashboard";
import AdminBallotView from "./pages/AdminBallotView";

export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/hub" element={<BallotHub />} />
        <Route path="/ballot/:id" element={<Ballot />} />
        <Route path="/history" element={<BallotHistory />} />
        <Route path="/admin" element={<AdminDashboard />} />
        <Route path="/admin/ballot/:id" element={<AdminBallotView />} />
      </Routes>
    </Router>
  );
}