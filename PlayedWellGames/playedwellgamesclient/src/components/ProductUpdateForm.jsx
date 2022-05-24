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


export default function ProductUpdateForm({preloadedValues}){

    
    const {
        register,
        handleSubmit,
        reset,
        formState: { errors }
      } = useForm({
        
      });

    const onSubmit = (data) => {
        console.log(data);
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

                <Button type='submit' style={{display:"block"}}>Update</Button>
               
            </form>
    );
}