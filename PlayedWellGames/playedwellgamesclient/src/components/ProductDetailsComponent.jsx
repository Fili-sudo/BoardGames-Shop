import * as React from 'react';
import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import axios from 'axios';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import { Typography } from '@mui/material';
import { IconButton } from '@mui/material';
import AddCircleOutlinedIcon from '@mui/icons-material/AddCircleOutlined';
import RemoveCircleIcon from '@mui/icons-material/RemoveCircle';

export default function ProductDetailsComponent(){

    const { id } = useParams();
    const [product, setProduct] = useState({});

    useEffect(() => {
        const fetchPosts = async () => {
          const res = await axios.get(`https://localhost:7020/api/Products/${id}`);
          setProduct(res.data);
        };
    
        fetchPosts();
      }, []);

    return(
        <Box sx={{ flexGrow: 1 }}>
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <img src={product.image} alt={product.productName} style={{objectFit: 'fill', height: 300, width: 300}}/>
            </Grid>
            <Grid item xs={6}>
              <Typography variant="h2" >
                {product.productName}
              </Typography>
              <Typography variant="body2" color="text.secondary" maxWidth={600}>
                {product.description}
              </Typography>
              <Typography variant="h2" >
                {product.price}{'\u20AC'}
              </Typography>
              <IconButton aria-label="plus"size="large" color="error">
                <RemoveCircleIcon fontSize="inherit"/>
              </IconButton>
              <Typography variant="h6" display="inline">
                12
              </Typography>
              <IconButton aria-label="plus" size="large" color="success">
                <AddCircleOutlinedIcon fontSize="inherit"/>
              </IconButton>
            </Grid>
            <Grid item xs={6}>
           
            <h1>Product Details for product with id= {product.id}</h1>
            </Grid>
          </Grid>
          
        </Box>

        
    );
}