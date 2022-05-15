import React from "react";
import ReactDOM from "react-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { Typography } from '@mui/material';
import * as yup from "yup";
import DenseAppBar from './DenseAppBar';
import "../myStyles/registerFormStyles.css";

const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/

const SignupSchema = yup.object().shape({
    firstName: yup.string().required("First Name is a required field")
        .matches(/^[a-zA-Z]+$/, 'Only aplhabetical characters allowed'),
    lastName: yup.string().required("Last Name is a required field")
        .matches(/^[a-zA-Z]+$/, 'Only aplhabetical characters allowed'),
    username: yup.string().required("Username Name is a required field")
        .matches(/^[a-zA-Z0-9_]+$/, 'Only alphanumerical characters and \'_\' allowed'),
    mail: yup.string().required("Mail is a required field")
        .email('must be valid mail'),
    password: yup.string().required("Password is a required field")
        .min(8, "Password must be between 8 and 16 characters")
        .max(16, "Password must be between 8 and 16 characters"),
    phone: yup.string().required("Phone is a required field")
              .matches(phoneRegExp, 'Please enter a valid phone number'),
    address: yup.string().required("Address is a required field")
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

export default function RegisterFormComponent(){

    const {
        register,
        handleSubmit,
        
        formState: { errors }
      } = useForm({
        resolver: yupResolver(SignupSchema)
      });
      const onSubmit = (data) => {
        console.log(data);
      };

    return (
        <>
        <header>
          <DenseAppBar title={"Register"}/>
        </header>
        <div style={{
          width:"100%", 
          alignItems: "center", 
          display: "flex", 
          justifyContent: "center"
        }}>
          <Typography variant="h2" >
            Register Form
          </Typography>
        </div>
        <div style={{
          background: "url(https://i.pinimg.com/originals/09/b2/ec/09b2ec4df26f5543093001d278ef26e6.png)",
          backgroundSize: "cover",
          backgroundRepeat: "no repeat",
          padding:"50px",  
          marginTop: 0,
          alignItems: "center", 
          display: "flex", 
          justifyContent: "center", 
          backgroundColor: "lightblue"
          }}>
          <form className="Form" 
                style={{
                  marginTop: "10%",
                  marginLeft:'auto', 
                  marginRight:'auto', 
                  boxShadow: "3px 3px 10px 0 black", 
                  borderRadius:"10px", 
                  backgroundColor: "#d27519"
                }} 
                onSubmit={handleSubmit(onSubmit)}
          >
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
              <input className="Form"
                {...register("username")} 
                placeholder = "Username"
                type = "text"
              />
              {errors.username && <p className="Form">{errors.username.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Mail</label>
              <input className="Form" 
                {...register("mail")}
                placeholder = "Mail"
                type = "mail"
              />
              {errors.mail && <p className="Form">{errors.mail.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Password</label>
              <input className="Form" 
                {...register("password")}
                placeholder = "Password"
                type = "password"
              />
              {errors.password && <p className="Form">{errors.password.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>First Name</label>
              <input className="Form"
                {...register("firstName")} 
                placeholder = "First Name"
                type = "text"
              />
              {errors.firstName && <p className="Form">{errors.firstName.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Last Name</label>
              <input className="Form"
                {...register("lastName")}
                placeholder = "Last Name"
                type = "text" 
              />
              {errors.lastName && <p className="Form">{errors.lastName.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Phone</label>
              <input className="Form"
                {...register("phone")}
                placeholder = "Phone"
                type = "tel" 
              />
              {errors.phone && <p className="Form">{errors.phone.message}</p>}
            </div>
            <div style={styledInputDiv}>
              <label style={styledInputLabel}>Address</label>
              <input className="Form" style={{width: "400px"}}
                {...register("address")}
                placeholder = "Address"
                type = "text" 
              />
              {errors.address && <p className="Form">{errors.address.message}</p>}
            </div>
            <input className="Form" type="submit" />
          </form>
        </div>
        
        
        </>
    )
}