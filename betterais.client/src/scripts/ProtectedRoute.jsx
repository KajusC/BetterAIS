import React from "react";
import { Navigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";

const ROLE_HIERARCHY = {
  student: 1,
  teacher: 2,
  admin: 3,
};

const ProtectedRoute = ({ minRole, children }) => {
  const { user } = useAuth();

  if (!user) {
    // Redirect to login if not authenticated
    return <Navigate to="/login" replace />;
  }

  const userRoleLevel = ROLE_HIERARCHY[user.role] || 0;
  if (userRoleLevel < ROLE_HIERARCHY[minRole]) {
    // Redirect to an error page if the user doesn't have sufficient access
    return <Navigate to="/error" replace />;
  }

  return children;
};

export default ProtectedRoute;
