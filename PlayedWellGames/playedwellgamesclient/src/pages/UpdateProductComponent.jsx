import * as React from 'react';
import { useForm } from "react-hook-form";
import { Outlet  } from "react-router-dom";

export default function UpdateProductComponent(){

    const {
        register,
        handleSubmit,
        
        formState: { errors }
      } = useForm();

      const onSubmit = (data) => {
        console.log(data);
      };

    return(
        <div style={{
            padding:"50px",  
            marginTop: 0,
            alignItems: "center", 
            display: "flex", 
            justifyContent: "center", 
            backgroundColor: "#9CC4EC"
            }}>
                <h1>heeei</h1>
            <form className="Form" 
                style={{
                  marginLeft:'auto', 
                  marginRight:'auto', 
                }} 
                onSubmit={handleSubmit(onSubmit)}
            >

            </form>
        </div>
    );
}