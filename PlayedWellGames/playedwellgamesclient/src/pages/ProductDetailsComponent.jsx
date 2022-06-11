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
import Alert from '@mui/material/Alert';
import Helmet from 'react-helmet';
import Footer from '../components/Footer';

export default function ProductDetailsComponent(){

    const { user } = useContext(UserContext);
    const { id } = useParams();
    const [product, setProduct] = useState({});
    const [quantity, setQuantity] = useState(1);
    const [addedToCartAlert, setAddedToCartAlert] = useState(false);
    const [errorAtCartAlert, setErrorAtCartAlert] = useState(false);
    const [alertContent, setAlertContent] = useState('');
    const [noImage] = useState("https://img.freepik.com/free-vector/children-playing-board-game-white-background_1308-94390.jpg?w=2000");

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
        setAlertContent("Product added successfully to your cart");
        setAddedToCartAlert(true);
      }
      else{
        let productArray = cart;
        if(productArray.find((arrayProduct) => { return arrayProduct.id === product.id })){
          console.log("item already in cart");
          setAlertContent("This product is already in your cart");
          setErrorAtCartAlert(true);
        }
        else {
          productArray.push(product);
          localStorage.setItem(`${user.username}cart`, JSON.stringify(productArray));
          setAlertContent("Product added successfully to your cart");
          setAddedToCartAlert(true);
        }
        //localStorage.removeItem(`${user.username}cart`);
      }
    }

    return(
      <>
        <Helmet bodyAttributes={{style: 'background-color : #EEEEEE'}}/>
        <header>
          <DenseAppBar title={`${product.productName} - info`}/>
        </header>
        {errorAtCartAlert ? <Alert onClose={() => {setErrorAtCartAlert(false);}} severity='error'>{alertContent}</Alert> : <></> }
        {addedToCartAlert ? <Alert onClose={() => {setAddedToCartAlert(false);}} severity='success'>{alertContent}</Alert> : <></> }
        <Box sx={{ flexGrow: 1, margin: '3% 7% 10% 7%'}}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={12} md={6}>
              <Box sx={{display: "flex"}}>
                <img src={product.image!=""? product.image : noImage} alt={product.productName} style={{objectFit: 'fill', height: 300, width: 300, borderRadius: "7px",boxShadow: "3px 3px 10px 0 black"}}/>
              </Box>
            </Grid>
            <Grid item xs={12} sm={12} md={6}>
              <Typography variant="h2" sx={{fontWeight: "500"}}>
                {product.productName}
              </Typography>
              <Typography variant="body2" color="text.secondary" maxWidth={600}>
                {product.description}
              </Typography>
              <Typography variant="h2" sx={{fontWeight: "300"}}>
                {product.price}{'\u20AC'}
              </Typography>
              <IconButton aria-label="plus"size="large" color="error"  onClick={(event) => updateAmount(-1)}>
                <RemoveCircleIcon fontSize="inherit"/>
              </IconButton>
              <IconButton aria-label="plus" size="large" color="success" onClick={(event) => updateAmount(1)}>
                <AddCircleOutlinedIcon fontSize="inherit"/>
              </IconButton>
              <Typography variant="subtitle1" display="inline">
                desired amount:{'   '} 
              </Typography>
              <Typography variant="h6" display="inline">
                {quantity}
              </Typography>
              <div >
                <Button variant="contained" size="large" startIcon={<AddShoppingCartIcon/>} sx={{borderRadius: '7px'}}
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
        <footer>
          <Footer style={{marginTop: "50px"}}/>
        </footer>
      </>
      

        
    );
}