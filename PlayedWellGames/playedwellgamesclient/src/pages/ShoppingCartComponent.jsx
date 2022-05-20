import * as React from 'react';
import MyCard from "../components/MyCard"
import { useEffect, useState, useContext  } from "react";
import { UserContext } from '../services/UserContext';
import { Typography } from '@mui/material';

export default function ShoppingCartComponent(){

    const { user } = useContext(UserContext);
    const [cart, setCart] = useState([]);
    const [totalPrice, setTotalPrice] = useState(0);

    useEffect(() => {
        const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
        const sumWithInitial = cart.reduce(
            (previousValue, currentValue) => previousValue + currentValue.price,
            totalPrice
          );
        setTotalPrice(sumWithInitial);
        setCart(cart);
    },[user]);

    const modifyTotalPrice = (value) =>{
        setTotalPrice(totalPrice + value);
    }

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
                                modify={modifyTotalPrice}
                            />
                        )))}
            </div>
            <div style={{flex: "1", textAlign: "right"}}>
                      <Typography variant="h4" sx={{position: "sticky", top: "0"}}>
                        Total Price: {' '}{totalPrice}{'\u20AC'}
                      </Typography>
            </div>
        </div>
        
    );
}