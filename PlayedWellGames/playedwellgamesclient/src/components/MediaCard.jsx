import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { styled, alpha } from '@mui/material/styles';
import { Translate } from '@mui/icons-material';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { Link } from 'react-router-dom';
import { useEffect, useState } from "react";
import axios from 'axios';

export default function ImgMediaCard(props) {


  return (
    <Card sx={{ 
      minWidth: '16%', 
      maxWidth: '16%',
      margin: "2%",
      display : 'inline-block', 
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
        <Typography gutterBottom variant="h5" component="div">
          {props.alt}  -  {props.price}{'\u20AC'}
        </Typography>
        <Typography variant="body2" color="text.secondary" maxWidth={150}>
          {props.description.substring(0, 99)}...
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small" startIcon={<AddShoppingCartIcon/>} onClick={() => props.addToCart(props.id)}>Add To Cart</Button>
        <Link to={`/product-details/${props.id}`}>
          <Button size="small">Learn More</Button>
        </Link>
        
      </CardActions>
    </Card>
  );
}
