import React from 'react'
import MainWindow from './MainWindow'
import LectureManager from '../../components/TeacherComponents/LectureManager';
import GradeManager from '../../components/TeacherComponents/GradeManager';
import StudentManager from '../../components/TeacherComponents/StudentManager';
import TeacherCard from '../../components/TeacherComponents/TeacherCard';


export default function TeacherWindow() {
    return (
        <MainWindow titleText="Dėstytojo valdymo skydas">
          <StudentManager />
          <GradeManager />
          <LectureManager />
          <TeacherCard teacher={{name: "John Doe", department: "Computer Science"}} />
        </MainWindow>
      );
}
