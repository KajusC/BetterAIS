import React, {useEffect, useState} from 'react'
import MainWindow from './MainWindow'
import LectureManager from '../../components/TeacherComponents/LectureManager';
import GradeManager from '../../components/TeacherComponents/GradeManager';
import StudentManager from '../../components/TeacherComponents/StudentManager';

export default function TeacherWindow() {

    return (
        <MainWindow titleText="Dėstytojo valdymo skydas">
          <StudentManager />
          <GradeManager />
          <LectureManager />
        </MainWindow>
      );
}
