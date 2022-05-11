import * as React from 'react';
import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import axios from 'axios';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import { Typography } from '@mui/material';
import { IconButton } from '@mui/material';
import AddCircleOutlinedIcon from '@mui/icons-material/AddCircleOutlined';
import RemoveCircleIcon from '@mui/icons-material/RemoveCircle';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import DenseAppBar from './DenseAppBar';
import { margin } from '@mui/system';

export default function ProductDetailsComponent(){

    const { id } = useParams();
    const [product, setProduct] = useState({});
    const [quantity, setQuantity] = useState(1);

    useEffect(() => {
        const fetchPosts = async () => {
          const res = await axios.get(`https://localhost:7020/api/Products/${id}`);
          setProduct(res.data);
        };
    
        fetchPosts();
      }, []);

    const updateAmount = (in_dec) =>{
      if(quantity + in_dec != 0 && quantity + in_dec != product.quantity){
        setQuantity(quantity + in_dec);
      }
    }

    return(
      <div>
        <header>
          <DenseAppBar productName={product.productName}/>
        </header>
        <Box sx={{ flexGrow: 1, margin: '10px'}}>
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
              <IconButton aria-label="plus"size="large" color="error"  onClick={(event) => updateAmount(-1)}>
                <RemoveCircleIcon fontSize="inherit"/>
              </IconButton>
              <Typography variant="subtitle1" display="inline">
                desired amount:{'   '} 
              </Typography>
              <Typography variant="h6" display="inline">
                {quantity}
              </Typography>
              <IconButton aria-label="plus" size="large" color="success" onClick={(event) => updateAmount(1)}>
                <AddCircleOutlinedIcon fontSize="inherit"/>
              </IconButton>
              <div style={{marginLeft: "4%"}}>
                <Button variant="contained" size="large" startIcon={<AddShoppingCartIcon/>} sx={{borderRadius: '15px'}}>Add To Cart</Button>
              </div>
              
            </Grid>
          </Grid>
          
        </Box>
      </div>

        
    );
}