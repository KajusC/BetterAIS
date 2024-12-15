import axios from "axios";

const API_URL = "https://localhost:7049/api/StudijuPrograma";

export const getAllPrograms = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;
    } catch (error) {
        console.error("Error fetching programs:", error);
        throw error;
    }
};

export const getProgramByCode = async (code) => {
    try {
        const response = await axios.get(`${API_URL}/${code}`);
        return response.data;
    } catch (error) {
        console.error("Error fetching program by code:", error);
        throw error;
    }
};