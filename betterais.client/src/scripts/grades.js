import axios from "axios";

// Base API URL
const API_URL = "https://localhost:7049/api/pazymiai"; // Replace with your actual API endpoint

// Axios instance for better control and reusability
const api = axios.create({
    baseURL: API_URL,
    headers: {
        "Content-Type": "application/json",
    },
});

// Fetch all grades
export const getAllGrades = async () => {
    try {
        const response = await api.get("/");
        return response.data;
    } catch (error) {
        console.error("Error fetching grades:", error.response?.data || error.message);
        throw error;
    }
};

// Fetch grades by student ID
export const getGradesByStudentId = async (studentId) => {
    try {
        const response = await api.get(`/student/${studentId}`);
        return response.data;
    } catch (error) {
        console.error("Error fetching grades for student:", error.response?.data || error.message);
        throw error;
    }
};

// Fetch grades by teacher ID
export const getGradesByTeacherId = async (teacherId) => {
    try {
        const response = await api.get(`/teacher/${teacherId}`);
        return response.data;
    } catch (error) {
        console.error("Error fetching grades for teacher:", error.response?.data || error.message);
        throw error;
    }
};

// Fetch a grade by ID
export const getGradeById = async (id) => {
    try {
        const response = await api.get(`/${id}`);
        return response.data;
    } catch (error) {
        console.error("Error fetching grade by ID:", error.response?.data || error.message);
        throw error;
    }
};

// Add a new grade
export const addGrade = async (gradeData) => {
    try {
        const response = await api.post("/", gradeData);
        return response.data;
    } catch (error) {
        console.error("Error adding grade:", error.response?.data || error.message);
        throw error;
    }
};

// Update an existing grade
export const updateGrade = async (id, gradeData) => {
    try {
        const response = await api.put(`/${id}`, gradeData);
        return response.data;
    } catch (error) {
        console.error("Error updating grade:", error.response?.data || error.message);
        throw error;
    }
};

// Delete a grade
export const deleteGrade = async (id) => {
    try {
        const response = await api.delete(`/${id}`);
        return response.data;
    } catch (error) {
        console.error("Error deleting grade:", error.response?.data || error.message);
        throw error;
    }
};
