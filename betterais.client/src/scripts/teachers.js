import axios from 'axios';

const API_URL = 'https://localhost:7049/api/destytojai'; // Update with your backend URL

export const getAllTeachers = async () => {
    try { 
        const response = await axios.get(API_URL);
        return response.data;
    }
    catch(error){
      console.error('Error fetching teachers:', error);
      throw error;
    }
};

export const getTeacherByVidko = async (vidko) => {
  try {
    const response = await axios.get(`${API_URL}/${vidko}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching teacher by Vidko:', error);
    throw error;
  }
};

export const addTeacher = async (teacherData) => {
  try {
    const response = await axios.post('https://localhost:7049/api/destytojai', teacherData);
    return response.data;
  } catch (error) {
    console.error('Error adding teacherAAAAAA:', error);
    throw error;
  }
};

export const updateTeacher = async (vidko, teacherData) => {
  try {
    const response = await axios.put(`${API_URL}/${vidko}`, teacherData);
    return response.data;
  } catch (error) {
    console.error('Error updating teacher:', error);
    throw error;
  }
};

export const deleteTeacher = async (vidko) => {
  try {
    const response = await axios.delete(`${API_URL}/${vidko}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting teacher:', error);
    throw error;
  }
};
