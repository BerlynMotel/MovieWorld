import React from "react";

interface ErrorProps {
  message : string;
}

const Error = ({
  message
}: ErrorProps) => {
  return (
    <>
      <br/>
      <div className="page-content center">
        <h1>{message}</h1>
      </div>
    </>
  );
};

export default Error;
