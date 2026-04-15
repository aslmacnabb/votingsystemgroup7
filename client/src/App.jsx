import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Ballot from "./pages/Ballot";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/ballot" element={<Ballot />} />
      </Routes>
    </Router>
  );
}

export default App;