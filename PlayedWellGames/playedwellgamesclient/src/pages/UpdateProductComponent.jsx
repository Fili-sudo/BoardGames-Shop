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
import ProductUpdateForm from '../components/ProductUpdateForm';


export default function UpdateProductComponent(){

    const [product, setProduct] = useState(null);
    
    
    const { id } = useParams();

    useEffect(() => {
        API.get(`Products/${id}`)
            .then(res => {
                setProduct(res.data);
            });
    },[]);

    return(
        <div style={{
            padding:"50px",  
            marginTop: 0,
            alignItems: "center", 
            display: "flex", 
            justifyContent: "center", 
            }}>
            {product ?<ProductUpdateForm preloadedValues={product}/>: <></>}
        </div>
    );
}