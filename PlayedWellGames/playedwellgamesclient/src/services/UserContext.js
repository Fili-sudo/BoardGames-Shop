import * as React from 'react';
import { useState, useEffect, createContext } from 'react';
import { useNavigate } from "react-router-dom";
import API from "../api";


export const UserContext = createContext();

export const UserProvider = ({ children }) => {

    const [user, setUser] = useState({ username: '', auth: '' });
    const navigate = useNavigate();

    const login = (data) => {
        let params = {
          username: data.username,
          password: data.password,
        };
        API
        .post('Authenticate/login', params)
        .then(function (response) {
          if (response.data.success === false) {
            console.log("error");
          } else {
            localStorage.setItem("auth", response.data.token);
            setUser({
                username: params.username,
                auth: response.data.token
            });
            setTimeout(() => {
              navigate("/");
            }, 2000);
          }
        })
      }
    
    const logout = () => {
        localStorage.removeItem("auth");
        setUser({
            username: '',
            auth: ''
        });
    };

    return (
      <UserContext.Provider value={{ user, login, logout }}>
        {children}
      </UserContext.Provider>
    );
  }
  