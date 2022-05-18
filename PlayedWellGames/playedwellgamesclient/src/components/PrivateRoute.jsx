import React from "react";
import { Navigate, Redirect, Route, useNavigate} from "react-router-dom";
import LoginFormComponent from "./LoginFormComponent";

const PrivateRoute = ({children}) => {
  const token = localStorage.getItem("auth");
  return (token ? children : <Navigate to="../login" />);
};

export default PrivateRoute;
