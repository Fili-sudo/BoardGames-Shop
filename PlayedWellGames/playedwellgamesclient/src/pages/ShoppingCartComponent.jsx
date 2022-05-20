import * as React from 'react';
import MyCard from "../components/MyCard"
import { useEffect, useState, useContext  } from "react";
import { UserContext } from '../services/UserContext';
import { Typography } from '@mui/material';

export default function ShoppingCartComponent(){

    const { user } = useContext(UserContext);
    const [cart, setCart] = useState([]);

    useEffect(() => {
        const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
        setCart(cart);
    },[user]);

    const Container = {
        padding: "20px",
        margin: "20px", 
         
        display: "flex",
    }

    return(
        <div style={Container}>
            <div style={{display: "inline-block", width: "50%"}}>
            {cart.map((item => (
                            <MyCard 
                                key={item.id}
                                image={item.image} 
                                productName={item.productName}
                                quantity={item.quantity}
                                desiredQuantity={item.desiredQuantity}
                                price={item.price}
                            />
                        )))}
            </div>
            <div style={{flex: "1"}}>
                      <Typography variant="h4" >
                        hello
                      </Typography>
            </div>
        </div>
        
    );
}