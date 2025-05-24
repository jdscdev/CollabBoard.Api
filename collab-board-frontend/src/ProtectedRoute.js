import { useContext } from 'react';
import { Navigate } from 'react-router-dom';
import { AuthContext } from './auth/AuthContext';

export default function ProtectedRoute({ children }) {
  const { token } = useContext(AuthContext);
  return token ? children : <Navigate to="/login" />;
}
