import React from "react";

export default function ErrorPage() {
  return (
    <>

      <div className="flex flex-col align-middle">
        <h1>404</h1>
        <h2>Page not found</h2>
        <p>
          The page you are looking for might have been removed, had its name
          changed or is temporarily unavailable.
        </p>
        <a href="/">Go to Homepage</a>
      </div>
    </>
  );
}
