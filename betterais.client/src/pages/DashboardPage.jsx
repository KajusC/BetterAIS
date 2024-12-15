import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';

import AdministratorWindow from './Windows/AdministratorWindow';
import TeacherWindow from './Windows/TeacherWindow';
import StudentWindow from './Windows/StudentWindow';

const DashboardPage = () => {
    const { user } = useAuth();

    // Debugging: Print user information to the console
    console.log("User Debug Info:", user);

    // If user is not logged in, redirect to login page
    if (!user) {
        return <Navigate to="/login" replace />;
    }

    // Role-based redirection
    switch (user.role) {
        case 'Administratorius':
            return <AdministratorWindow />;
        case 'Destytojas':
            return <TeacherWindow />;
        case 'Studentas':
            return <StudentWindow />;
        default:
            console.error("Unknown role:", user.role);
            return <Navigate to="/login" replace />;
    }
};

export default DashboardPage;
