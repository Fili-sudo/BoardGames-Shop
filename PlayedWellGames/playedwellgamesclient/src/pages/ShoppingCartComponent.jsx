import * as React from 'react';
import MyCard from "../components/MyCard"
import { useEffect, useState, useContext  } from "react";
import { UserContext } from '../services/UserContext';
import { Typography } from '@mui/material';
import Button from '@mui/material/Button';
import API from '../api';
import axios from 'axios';

export default function ShoppingCartComponent({rerenderCart}){

    const { user } = useContext(UserContext);
    const [cart, setCart] = useState([]);
    const [totalPrice, setTotalPrice] = useState(0);
    const [order, setOrder] = useState({});

    useEffect(() => {
        const order = JSON.parse(localStorage.getItem(`${user.username}order`));
        var id = user.id;
        if(id == ''){
            id=null;
        }
        console.log(id);
        console.log(user.username);
        if(!order){
            API.post("Orders", { userId: id })
            .then(res => {
                console.log(res);
                console.log(res.data);
                setOrder(res.data);
                localStorage.setItem(`${user.username}order`, JSON.stringify(res.data.id));
              });
        }
            else{
                API.get(`Orders/${order}`)
                .then(res => {
                    console.log(res);
                    console.log(res.data);
                    setOrder(res.data);
                  });
            }


        const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
        const initialValue = 0;
        const sumWithInitial = cart.reduce(
            (previousValue, currentValue) => previousValue + currentValue.price*currentValue.desiredQuantity,
            initialValue
          );
        setTotalPrice(sumWithInitial);
        setCart(cart);
    },[user]);


    const addItemsToOrder = () => {
        //const requestArray = cart.map((item) => {
        //    API.post(`OrderItems`,{
        //        quantity: item.desiredQuantity,
        //        productId: item.id,
        //        
        //    })
        //})
//
        //axios.all([
//
        //]);
    }

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
                                id={item.id}
                                image={item.image} 
                                productName={item.productName}
                                quantity={item.quantity}
                                desiredQuantity={item.desiredQuantity}
                                price={item.price}
                                modify={modifyTotalPrice}
                                rerender={rerenderCart}
                            />
                        )))}
            </div>
            <div style={{flex: "1", textAlign: "right"}}>
                      <Typography variant="h4" sx={{position: "sticky", top: "0"}}>
                        Total Price: {' '}{totalPrice}{'\u20AC'}
                        <p>hello: {order.id}</p>
                        <Button variant="contained" sx={{position: "sticky", top: "0"}}>Place order</Button>
                      </Typography>
                      
            </div>
        </div>
        
    );
}