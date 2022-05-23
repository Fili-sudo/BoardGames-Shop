import * as React from 'react';
import { useState, useEffect, createContext } from 'react';
import { useNavigate } from "react-router-dom";
import API from "../api";


export const UserContext = createContext();

export const UserProvider = ({ children }) => {

    const [user, setUser] = useState({
       username: '', 
       auth: '',
       id: '',
       role: ''});
    const navigate = useNavigate();

    useEffect(() => {
      const auth = JSON.parse(localStorage.getItem('auth'));
      if(auth != null){
        setUser({
          username: auth.username, 
          auth: auth.token,
          id: auth.id,
          role: auth.role
        });
      }
    },[])

    const login = (data) => {
        let params = {
          username: data.username,
          password: data.password,
        };
        API
        .post('Authenticate/login', params)
        .then(function (response) {
            localStorage.setItem(`auth`, JSON.stringify({
              token: response.data.token,
              username: params.username,
              id: response.data.id,
              role: response.data.role
            }));
            setUser({
                username: params.username,
                auth: response.data.token,
                id: response.data.id,
                role: response.data.role
            });
            setTimeout(() => {
              if(response.data.role == 0){
                console.log("user");
              }
                else{
                  console.log("admin");
                }
              navigate("/");
            }, 2000);
          
        }).catch(error =>{
          alert("Wrong username or password");
        })
      }
    
    const logout = () => {
        localStorage.removeItem("auth");
        const orderId = JSON.parse(localStorage.getItem(`${user.username}order`));
        if(orderId){
          API.delete(`Orders/${orderId}`);
          localStorage.removeItem(`${user.username}order`);
        }
        setUser({
            username: "",
            auth: '',
            id: '',
            role: ''
        });
    };

    return (
      <UserContext.Provider value={{ user, login, logout }}>
        {children}
      </UserContext.Provider>
    );
  }
  