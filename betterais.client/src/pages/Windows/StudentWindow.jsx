import React, { useEffect, useState } from 'react'
import MainWindow from './MainWindow'
import ProfileOverview from '../../components/studentComponents/ProfileOverview'
import RecentGrades from '../../components/studentComponents/RecentGrades'
import UpcomingLectures from '../../components/studentComponents/UpcomingLectures'
import PendingTasks from '../../components/studentComponents/PendingTasks'
import ModuleSummary from '../../components/studentComponents/ModuleSummary'
import {jwtDecode} from 'jwt-decode';
import { getStudentByVidko } from '../../scripts/studentAPI'
import ShowGrades from '../gradePages/ShowGrades'

export default function StudentWindow() {

    const [studentData, setStudentData] = useState(null);
    useEffect(() => {
        const token = localStorage.getItem('authToken');
        if (!token) {
            history.push('/login');
        }
        const decodedToken = jwtDecode(token);
        const vidko = decodedToken.unique_name

        getStudentByVidko(vidko)
            .then((data) => {
                setStudentData(data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }, []);


    if (!studentData) {
        return <MainWindow titleText="Studento valdymo skydas">Loading...</MainWindow>;
    }
    
    return (
        <MainWindow titleText="Studento valdymo skydas">
        <ProfileOverview studentInfo={studentData} />
            <RecentGrades studentId={studentData.vidko} />
            <UpcomingLectures studentId={studentData.vidko} />
      </MainWindow>
      );
}
