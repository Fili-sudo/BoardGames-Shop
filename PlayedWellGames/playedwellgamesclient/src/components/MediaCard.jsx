import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { styled, alpha } from '@mui/material/styles';
import { Translate } from '@mui/icons-material';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { Link } from 'react-router-dom';
import { useEffect, useState } from "react";
import axios from 'axios';
import { style } from '@mui/system';
import { useNavigate } from "react-router-dom";


export default function ImgMediaCard(props) {
  const navigate = useNavigate();

  return (
    <Card sx={{ 
      /*minWidth: '16%', 
      maxWidth: '16%',*/
      borderRadius: 3,
      margin: "30px 15% 30px 15%",
      display: "flex",
      flexDirection: "column",
      justifyContent: "space-between",
      /*display : 'inline-block', */
      '& .MuiCardMedia-img': { 
        objectFit: 'contain'
      },
      ":hover": { 
        boxShadow: 10, 
        transform: 'translate(0px, -5px)' 
      } 
    }}>
      <CardMedia
         component="img"
         alt = {props.alt}
         height="140"
         image= {props.image}
      />
      <CardContent>
        <Box sx={{ display:"flex", justifyContent:"center"}}>
          <Typography gutterBottom variant="h5" component="div" sx={{fontWeight: "700"}}>
            {props.alt}
          </Typography>
        </Box>
        <Box sx={{ display:"flex", justifyContent:"center" }}>
          <Typography gutterBottom variant="h5" component="div" sx={{display:"block", fontWeight: "500"}}>
            {props.price}{'\u20AC'}
          </Typography>
        </Box>
        <Typography variant="body2" >
          {props.description.length>50? (props.description.substring(0, 46) + "..."): props.description}{/*props.tags*/}
        </Typography>
      </CardContent>
      <CardActions sx={{padding: "5px", display: "block"}}>
        <Box sx={{ display:"flex", justifyContent:"center", marginBottom: "15px"}}>
          <Button size="medium" variant='contained' startIcon={<AddShoppingCartIcon/>} 
              onClick={() => props.addToCart({
                id: props.id,
                image: props.image,
                productName: props.alt,
                description: props.description,
                price: props.price,
                quantity: props.quantity,
                desiredQuantity: 1,
                tags: props.tags
              })}>Add To Cart</Button>
        </Box> 
        <Box sx={{ display:"flex", justifyContent:"center"}}>
          <Button size="small" color="secondary" onClick={(event) => navigate(`/product-details/${props.id}`)}>Learn More </Button>
        </Box>
      </CardActions>
    </Card>
  );
}
