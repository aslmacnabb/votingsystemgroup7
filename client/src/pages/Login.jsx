import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import "../styles/Login.css";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const { login } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    const role = await login(username, password);

    if (role === "admin") navigate("/admin");
    else if (role === "user" || role === "voter") navigate("/hub");
    else alert("Invalid login");
  };

  return (
    <div className="login-container">
      <div className="login-split">
        <div className="login-image-panel" />

        <div className="login-form-panel">
          <div className="login-card">
            <h1 className="login-title">Login</h1>
            <form onSubmit={handleSubmit} className="login-form">
              <label>
                Username
                <input
                  placeholder="Username"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                />
              </label>

              <label>
                Password
                <input
                  type="password"
                  placeholder="Password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </label>

              <button type="submit">Login</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}