import axios from 'axios';

const API_URL = 'https://localhost:7049/api';

export const getAllModules = async () => {
    const response = await axios.get(`${API_URL}/Modulis`);
    return response.data;
};
export const deleteLecture = async (lectureId) => {
    try {
        const response = await axios.delete(`${API_URL}/Paskaitos/${lectureId}`);
        return response.data;
    } catch (error) {
        console.error('Error deleting lecture:', error);
        throw error;
    }
};
export const getLecturesByModule = async (moduleCode) => {
    const response = await axios.get(`${API_URL}/Paskaitos?moduleId=${moduleCode}`);
    return response.data;
};

export const assignLecture = async (lectureData) => {
    const response = await axios.post(`${API_URL}/Paskaitos`, lectureData);
    return response.data;
};
export const addLecture = async (lectureData) => {
    const response = await axios.post(`${API_URL}/Paskaitos`, lectureData);
    return response.data;
};
export const getLectureById = async (lectureId) => {
    try {
        const response = await axios.get(`${API_URL}/Paskaitos/${lectureId}`);
        return response.data;
    } catch (error) {
        console.error('Error fetching lecture by ID:', error);
        throw error;
    }
};
export const updateLecture = async (lectureId, updatedData) => {
    try {
        const response = await axios.put(`${API_URL}/Paskaitos/${lectureId}`, updatedData, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        console.error('Error updating lecture:', error);
        throw error;
    }
};
export const getAllTeachers = async () => {
    try {
        // Fetch teachers and users separately
        const [teachersResponse, usersResponse] = await Promise.all([
            axios.get(`${API_URL}/Destytojai`),
            axios.get(`${API_URL}/Vartotojai`)
        ]);

        const teachers = teachersResponse.data;
        const users = usersResponse.data;

        // Combine teacher and user data
        const combinedData = teachers.map((teacher) => {
            const user = users.find((u) => u.vidko === teacher.vidko);
            return {
                vidko: teacher.vidko,
                vardas: user?.vardas || 'N/A',
                pavarde: user?.pavarde || 'N/A',
            };
        });

        return combinedData;
    } catch (error) {
        console.error('Error fetching teachers:', error);
        throw error;
    }
};
export const getAllFaculties = async () => {
    try {
        const response = await axios.get(`${API_URL}/Fakultetai`);
        return response.data;
    } catch (error) {
        console.error('Error fetching faculties:', error);
        throw error;
    }
};
export const assignLectureToTimetable = async (timetableData) => {
    try {
        const response = await axios.post(API_URL, timetableData, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        console.error('Error assigning lecture to timetable:', error);
        throw error;
    }
};
export const getUpcomingLectures = async () => {
    try {
        const response = await axios.get(`${API_URL}/Paskaitos/Upcoming`);
        return response.data;
    } catch (error) {
        console.error('Error fetching upcoming lectures:', error);
        throw error;
    }
};
export const getLecturesByTeacher = async (teacherId) => {
    const response = await axios.get(
        `https://localhost:7049/api/Paskaitos/ByTeacher/${teacherId}`
    );
    return response.data;
};

