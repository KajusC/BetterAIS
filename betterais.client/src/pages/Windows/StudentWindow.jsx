import React from 'react'
import MainWindow from './MainWindow'
import ProfileOverview from '../../components/studentComponents/ProfileOverview'
import RecentGrades from '../../components/studentComponents/RecentGrades'
import UpcomingLectures from '../../components/studentComponents/UpcomingLectures'
import PendingTasks from '../../components/studentComponents/PendingTasks'
import ModuleSummary from '../../components/studentComponents/ModuleSummary'

export default function StudentWindow() {
    return (
        <MainWindow titleText="Studento valdymo skydas">
            <ProfileOverview />
            <RecentGrades />
            <UpcomingLectures />
            <PendingTasks />
            <ModuleSummary />

        </MainWindow>
      );
}
