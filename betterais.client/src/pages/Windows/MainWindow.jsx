import React from "react";
import { Children } from "react";


const MainWindow = ({ titleText, children }) => {
  return (
    <div className="min-h-screen bg-gray-100 dark:bg-gray-900 p-8 transition-colors duration-300">
      <h1 className="text-4xl font-bold text-gray-800 dark:text-gray-200 mb-8 text-center">
        {titleText}
      </h1>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
        {Children.map(children, (child) => (
          <div className="Row">{child}</div>
        ))}
      </div>
    </div>
  );
};

export default MainWindow;
