import { createContext, useContext, useState } from "react";
import { login as apiLogin } from "../services/api";

const AuthContext = createContext();

export function AuthProvider({ children }) {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(false);

  const login = async (username, password) => {
    setLoading(true);
    try {
      const response = await apiLogin(username, password);
      
      if (response.success) {
        setUser({ 
          username: response.username, 
          password: password,
          role: response.role,
          userId: response.userId
        });
        return response.role;
      } else {
        console.error(response.message);
        return null;
      }
    } catch (error) {
      console.error("Login error:", error);
      return null;
    } finally {
      setLoading(false);
    }
  };

  const logout = () => setUser(null);

  return (
    <AuthContext.Provider value={{ user, login, logout, loading }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext);
}