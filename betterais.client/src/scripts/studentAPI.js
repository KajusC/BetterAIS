import axios from "axios";

const API_URL = "https://localhost:7049/api/studentai";

export const getAllStudents = async (query = '') => {
    const queryURL = query ? `?programosKodas=${query}` : ''
  
    try {
      const response = await axios.get(`${API_URL}${queryURL}`)
      return response.data
    } catch (error) {
      console.error('Error fetching students:', error)
      throw error
    }
  }

export const getStudentByVidko = async (vidko) => {
	try {
		const response = await axios.get(`${API_URL}/${vidko}`);
		return response.data;
	} catch (error) {
		console.error("Error fetching student by Vidko:", error);
		throw error;
	}
};

export const addStudent = async (studentData) => {
    try {
        const response = await axios.post(API_URL, studentData);
        return response.data;
    } catch (error) {
        console.error("Error adding student:", error);
        throw error;
    }
};

export const updateStudent = async (vidko, studentData) => {
    studentData.slaptazodis = "abc";

    console.log(vidko, studentData);
    try {
      const response = await axios.put(`${API_URL}/${vidko}`, studentData);
      return response;
    } catch (error) {
      console.error('Error updating student:', error);
      throw error;
    }
  };

export const deleteStudent = async (vidko) => {
    try {
        const response = await axios.delete(`${API_URL}/${vidko}`);
        return response.data;
    } catch (error) {
        console.error("Error deleting student:", error);
        throw error;
    }
}

export const downloadPDF = async (storePath, vidko) => {
    const asciiPath = encodeURIComponent(storePath);
    try {
        const response = await axios.post(`${API_URL}/pdf?path=${asciiPath}&vidko=${vidko}`);
        return response.status;
    } catch (error) {
        console.error("Error downloading pdf:", error);
        throw error;
    }
}
