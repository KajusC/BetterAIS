import axios from 'axios';

const API = axios.create({
  baseURL: 'http://localhost:5000', // Replace with your API base URL
});

export const fetchStudents = () => API.get('/students');
export const fetchTeachers = () => API.get('/teachers');
export const fetchTimetable = () => API.get('/timetable');
