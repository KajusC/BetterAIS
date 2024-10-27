import React from 'react';
import ProfileOverview from '../components/ProfileOverview';
import RecentGrades from '../components/RecentGrades';
import UpcomingLectures from '../components/UpcomingLectures';
import PendingTasks from '../components/PendingTasks';
import ModuleSummary from '../components/ModuleSummary';
import Notifications from '../components/Notifications';

const MainWindow = () => {
  return (
    <div className="min-h-screen bg-gray-100 dark:bg-gray-900 p-8 transition-colors duration-300">
      <h1 className="text-4xl font-bold text-gray-800 dark:text-gray-200 mb-8 text-center">
        Welcome to Your Academic Dashboard
      </h1>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
        <ProfileOverview />
        <RecentGrades />
        <UpcomingLectures />
        <PendingTasks />
        <ModuleSummary />
        <Notifications />
      </div>
    </div>
  );
};

export default MainWindow;
