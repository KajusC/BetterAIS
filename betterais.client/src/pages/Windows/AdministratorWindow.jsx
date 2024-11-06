import React from "react";
import MainWindow from "./MainWindow";
import AdministratorCard from "../../components/administratorComponents/AdministratorCard";
import StudentManager from "../../components/administratorComponents/StudentManager";
import TeacherManager from "../../components/administratorComponents/TeacherManager";
import LectureManager from "../../components/administratorComponents/LectureManager";

export default function AdministratorWindow() {
  const admin = {
    name: "John Doe",
    position: "Administrator",
  };
  return (
    <>

      <MainWindow titleText="Administrator panel of Academic Info System">
        <StudentManager />
        <TeacherManager />
        <LectureManager />
        <AdministratorCard admin={admin} />
      </MainWindow>

    </>
  );
}