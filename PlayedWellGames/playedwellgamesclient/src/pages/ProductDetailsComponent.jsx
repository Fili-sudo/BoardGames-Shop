import * as React from 'react';
import { useParams } from 'react-router-dom';
import { useState, useEffect, useContext } from 'react';
import { UserContext } from '../services/UserContext';
import axios from 'axios';
import API from '../api';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import { Typography } from '@mui/material';
import { IconButton } from '@mui/material';
import AddCircleOutlinedIcon from '@mui/icons-material/AddCircleOutlined';
import RemoveCircleIcon from '@mui/icons-material/RemoveCircle';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import DenseAppBar from '../components/DenseAppBar';
import { margin } from '@mui/system';

export default function ProductDetailsComponent(){

    const { user } = useContext(UserContext);
    const { id } = useParams();
    const [product, setProduct] = useState({});
    const [quantity, setQuantity] = useState(1);

    useEffect(() => {
        const fetchProducts = async () => {
          const res = await API.get(`Products/${id}`);
          setProduct(res.data);
        };
    
        //console.log(user);
        fetchProducts();
      }, []);

    const updateAmount = (in_dec) =>{
      if(quantity + in_dec != 0 && quantity + in_dec != product.quantity){
        setQuantity(quantity + in_dec);
      }
    }
    const addToCart2 = (product) => {
      const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
      if(cart == null){
        let productArray = [];
        productArray.push(product);
        localStorage.setItem(`${user.username}cart`, JSON.stringify(productArray));
      }
      else{
        let productArray = cart;
        if(productArray.find((arrayProduct) => { return arrayProduct.id === product.id })){
          console.log("item already in cart");
        }
        else productArray.push(product);
        localStorage.setItem(`${user.username}cart`, JSON.stringify(productArray));
        //localStorage.removeItem(`${user.username}cart`);
      }
    }

    return(
      <div>
        <header>
          <DenseAppBar title={`${product.productName} - info`}/>
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
                <Button variant="contained" size="large" startIcon={<AddShoppingCartIcon/>} sx={{borderRadius: '15px'}}
                  onClick={() => addToCart2({
                    id: product.id,
                    image: product.image,
                    productName: product.productName,
                    description: product.description,
                    price: product.price,
                    quantity: product.quantity,
                    desiredQuantity: quantity,
                    tags: product.tags
                  })}>Add To Cart</Button>
              </div>
              
            </Grid>
          </Grid>
          
        </Box>
      </div>

        
    );
}