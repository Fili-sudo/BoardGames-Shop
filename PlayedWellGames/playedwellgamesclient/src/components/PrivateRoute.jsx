import React from "react";
import { Navigate, Redirect, Route, useNavigate} from "react-router-dom";
import LoginFormComponent from "../pages/LoginFormComponent";

const PrivateRoute = ({children}) => {
  const token = JSON.parse(localStorage.getItem("auth"));
  var admin = 0;
  if(token){
    if(token.role == 1){
      admin = 1;
    }
  }
  return (token&&admin ? children : <Navigate to="../login" />);
};

export default PrivateRoute;
