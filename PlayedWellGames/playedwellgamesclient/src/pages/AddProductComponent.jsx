import * as React from 'react';
import { useForm } from "react-hook-form";
import { useParams  } from "react-router-dom";
import { useEffect, useState } from "react";
import ReactDOM from 'react-dom';
import API from '../api';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import Input from '@mui/material/Input';
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import Button from '@mui/material/Button';
import FormControl from '@mui/material/FormControl';
import { useNavigate } from "react-router-dom";

export default function AddProductComponent(){

    const navigate = useNavigate();
    
    const {
        register,
        handleSubmit,
        reset,
        formState: { errors }
      } = useForm({
        
      });

    const onSubmit = (data) => {
        console.log(data);
        API.post(`Products/`,{
            productName: data.productName,
            description: data.description,
            price: data.price,
            quantity: data.quantity,
            tags: data.tags,
            image: data.image
        }).then(res => {
            console.log(res);
        });
        setTimeout(() => {
            navigate(-1);
          }, 1000);
    };

    return(
        <div style={{
            padding:"50px",  
            marginTop: 0,
            alignItems: "center", 
            display: "flex", 
            justifyContent: "center", 
            }}>
            <form
                style={{
                  marginLeft:'auto', 
                  marginRight:'auto', 
                }} 
                onSubmit={handleSubmit(onSubmit)}
            >
        
               
                <InputLabel htmlFor="productName">Product Name*</InputLabel>
                <OutlinedInput 
                    {...register("productName", { required: true })} 
                    id="productName" 
                />
        
                <InputLabel htmlFor="description">Description*</InputLabel>
                <OutlinedInput 
                    {...register("description", { required: true })} 
                    id="description" 
                    multiline={true}
                    maxRows={5}
                />
                
                <InputLabel htmlFor="price" >Price*</InputLabel>
                <OutlinedInput 
                    {...register("price", { required: true })} 
                    id="price" 
                    type='number'
                />

                <InputLabel htmlFor="quantity" >Quantity*</InputLabel>
                <OutlinedInput 
                    {...register("quantity", { required: true })} 
                    id="quantity" 
                    type='number'
                />

                <InputLabel htmlFor="tags" >Tags*</InputLabel>
                <OutlinedInput 
                    {...register("tags", { required: true })} 
                    id="tags" 
                />

                <InputLabel htmlFor="image" >Image</InputLabel>
                <OutlinedInput 
                    {...register("image")} 
                    id="image" 
                />
                {(errors.productName || errors.description || errors.price || errors.quantity || errors.tags) && <p>Please fill all required fields</p>}
                <Button type='submit'  
                    size="large" 
                    variant="contained" 
                    style={{display:"block", marginTop: "10px", marginLeft:"auto", marginRight:"auto"}}>
                    Add
                </Button>
            
            </form>
        </div>
    );
}