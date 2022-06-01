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


export default function ProductUpdateForm({preloadedValues}){

    const navigate = useNavigate();
    
    const {
        register,
        handleSubmit,
        reset,
        formState: { errors }
      } = useForm({
        
      });

    const onSubmit = (data) => {
        const auth = JSON.parse(localStorage.getItem('auth'));
        const token = auth.token;
        API.put(`Products/${preloadedValues.id}`,{
            productName: data.productName,
            description: data.description,
            price: data.price,
            quantity: data.quantity,
            tags: data.tags,
            image: data.image
        },{ headers: {
            Authorization: `Bearer ${token}`
        }}).then(res => {
            console.log(res);
        }).catch(error => {
            alert("Your authentication token has expired. Please log in again to perform this action.");
        });
        setTimeout(() => {
            navigate(-1);
          }, 1000);
    };
    


    return(
            <form
                style={{
                  marginLeft:'auto', 
                  marginRight:'auto', 
                }} 
                onSubmit={handleSubmit(onSubmit)}
            >
        
               
                <InputLabel htmlFor="productName">Product Name</InputLabel>
                <OutlinedInput 
                    defaultValue={preloadedValues.productName}
                    {...register("productName")} 
                    id="productName" 
                    name="productName"
                />
        
                <InputLabel htmlFor="description">Description</InputLabel>
                <OutlinedInput 
                    defaultValue={preloadedValues.description}
                    {...register("description")} 
                    id="description" 
                    name="description"
                    multiline={true}
                    maxRows={5}
                />
                
                <InputLabel htmlFor="price" >Price</InputLabel>
                <OutlinedInput 
                    defaultValue={preloadedValues.price}
                    {...register("price")} 
                    id="price" 
                    type='number'
                    name="price"
                />

                <InputLabel htmlFor="quantity" >Quantity</InputLabel>
                <OutlinedInput 
                    defaultValue={preloadedValues.quantity}
                    {...register("quantity")} 
                    id="quantity" 
                    type='number'
                    name="quantity" 
                />

                <InputLabel htmlFor="tags" >Tags</InputLabel>
                <OutlinedInput 
                    defaultValue={preloadedValues.tags}
                    {...register("tags")} 
                    id="tags" 
                    name="tags"
                />

                <InputLabel htmlFor="image" >Image</InputLabel>
                <OutlinedInput 
                    defaultValue={preloadedValues.image}
                    {...register("image")} 
                    id="image" 
                    name="image"
                />

                <Button type='submit'  
                    size="large" 
                    variant="contained" 
                    style={{display:"block", marginTop: "10px", marginLeft:"auto", marginRight:"auto"}}>
                    Update
                </Button>
               
            </form>
    );
}