import React from "react";
import ReactDOM from "react-dom";
import { Link } from 'react-router-dom';
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { Typography } from '@mui/material';
import * as yup from "yup";
import DenseAppBar from '../components/DenseAppBar';
import Helmet from 'react-helmet';
import API from "../api";
import { useNavigate } from "react-router-dom";
import { useContext } from 'react';
import { UserContext }   from "../services/UserContext"
import Button from '@mui/material/Button';
//import Link from '@mui/material/Link';
import "../myStyles/registerFormStyles.css";

const LoginSchema = yup.object().shape({
    username: yup.string().required("You didn't filled Username field"),
    password: yup.string().required("You didn't filled Password field")
  });

const styledInputDiv = {
    marginBottom: 10, 
    marginLeft: "10px", 
    marginRight: "10px"
  }
const styledInputLabel = {
    color: "#FFFFFF", 
    fontWeight: 900
  }

export default function LoginFormComponent(){

    const {user, login} = useContext(UserContext);
    const navigate = useNavigate();
    const {
        register,
        handleSubmit,
        formState: { errors }
      } = useForm({
        resolver: yupResolver(LoginSchema)
      });

      //const onSubmit = (data) => {
      //  console.log(data);
      //};
      //const logins = (data) => {
      //  let params = {
      //    username: data.username,
      //    password: data.password,
      //  };
      //  API
      //  .post('Authenticate/login', params)
      //  .then(function (response) {
      //    //   IF EMAIL ALREADY EXISTS
      //    if (response.data.success === false) {
      //      console.log("error");
      //    } else {
      //      localStorage.setItem("auth", response.data.token);
      //      setTimeout(() => {
      //        navigate("../onlyu");
      //      }, 2000);
      //    }
      //  })
      //}


      return(
        <>
        <Helmet bodyAttributes={{style: 'background-color : #EEEEEE'}}/>
        <header>
          <DenseAppBar title={"Login"}/>
        </header>
        <div style={{
          padding:"50px",  
          marginTop: 0,
          alignItems: "center", 
          display: "flex", 
          justifyContent: "center", 
          }}>
          <form className="Form" 
                style={{
                  marginLeft:'auto', 
                  marginRight:'auto', 
                  boxShadow: "3px 3px 10px 0 black", 
                  borderRadius:"10px", 
                  backgroundColor: "#d27519"
                }} 
                onSubmit={handleSubmit(login)}>
            <div style={{ marginBottom: "20px", height: "150px", width: "100%"}}>
              <img src="https://www.wall-street.ro/image_thumbs/articles/9/8/6/198669/p_198669_900x675-00-65.jpg" 
                   alt="register_image"
                   style={{ width:"100%",
                            height:"100%",
                            objectFit:"cover",
                            borderRadius: "10px"
                          }}
              />
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Username</label>
              <input className="Form" style={{width: "400px"}}
                {...register("username")} 
                placeholder = "Username"
                type = "text"
              />
              {errors.username && <p className="Form">{errors.username.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Mail</label>
              <input className="Form" style={{width: "400px"}}
                {...register("password")}
                placeholder = "Password"
                type = "password"
              />
              {errors.password && <p className="Form">{errors.password.message}</p>}
            </div>
            <div style={{marginBottom: "10px"}}>
                <Typography variant="body1" sx={{color: "#FFFFFF", marginLeft: "10px"}}>Don't have an account?</Typography>
                <Link style={{color: "#FFFFFF", marginLeft: "10px"}} to={'../register-user'} >Register now</Link>
            </div>
            
            
            <Button type='submit'  
                    size="large" 
                    variant="contained" 
                    style={{display:"block", marginTop: "10px",marginBottom: "10px", marginLeft:"auto", marginRight:"auto"}}>
                    Login
            </Button>
          </form>
        </div>
            </>

      )

}
