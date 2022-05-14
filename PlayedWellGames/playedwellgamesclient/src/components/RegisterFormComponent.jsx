import React from "react";
import ReactDOM from "react-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "../myStyles/registerFormStyles.css";

const SignupSchema = yup.object().shape({
    firstName: yup.string().required()
        .matches(/^[a-zA-Z]+$/, 'Only aplhabetical characters allowed'),
    lastName: yup.string().required()
        .matches(/^[a-zA-Z]+$/, 'Only aplhabetical characters allowed'),
    username: yup.string().required()
        .matches(/^[a-zA-Z0-9_]+$/, 'Only alphanumerical characters and \'_\' allowed'),
    mail: yup.string().required()
        .email('must be valid mail'),
    password: yup.string().required()
        .min(8, "Password must be between 8 and 16 characters")
        .max(16, "Password must be between 8 and 16 characters"),
    phone: yup.string().required(),
    address: yup.string().required()
  });

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
        <div style={{width:"100%", alignItems: "center", display: "flex", justifyContent: "center"}}>
          <h1 style={{marginLeft:'auto', marginRight:'auto'}}>Register Form</h1>
        </div>
        <div style={{width:"100%", alignItems: "center", display: "flex", justifyContent: "center", backgroundColor: "lightblue"}}>
          <form className="Form" style={{marginLeft:'auto', marginRight:'auto', border: "3px solid", padding: "50px"}} onSubmit={handleSubmit(onSubmit)}>
            <div style={{ marginBottom: 10 }}>
              <label>Username</label>
              <input className="Form"
                {...register("username")} 
                placeholder = "Username"
                type = "text"
              />
              {errors.username && <p className="Form">{errors.username.message}</p>}
            </div>
            <div style={{ marginBottom: 10}}>
              <label>Mail</label>
              <input className="Form" 
                {...register("mail")}
                placeholder = "Mail"
                type = "mail"
              />
              {errors.mail && <p className="Form">{errors.mail.message}</p>}
            </div>
            <div style={{ marginBottom: 10 }}>
              <label>Password</label>
              <input className="Form"
                {...register("password")}
                placeholder = "Password"
                type = "password"
              />
              {errors.password && <p className="Form">{errors.password.message}</p>}
            </div>
            <div style={{ marginBottom: 10 }}>
              <label>First Name</label>
              <input className="Form"
                {...register("firstName")} 
                placeholder = "First Name"
                type = "text"
              />
              {errors.firstName && <p className="Form">{errors.firstName.message}</p>}
            </div>
            <div style={{ marginBottom: 10 }}>
              <label>Last Name</label>
              <input className="Form"
                {...register("lastName")}
                placeholder = "Last Name"
                type = "text" 
              />
              {errors.lastName && <p className="Form">{errors.lastName.message}</p>}
            </div>
            <div style={{ marginBottom: 10 }}>
              <label>Phone</label>
              <input className="Form"
                {...register("phone")}
                placeholder = "Phone"
                type = "tel" 
              />
              {errors.phone && <p className="Form">{errors.phone.message}</p>}
            </div>
            <div style={{ marginBottom: 10 }}>
              <label>Address</label>
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