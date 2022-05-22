import * as React from 'react';
import MyCard from "../components/MyCard"
import { useEffect, useState, useContext  } from "react";
import { UserContext } from '../services/UserContext';
import { Typography } from '@mui/material';
import Button from '@mui/material/Button';
import API from '../api';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import TextField from '@mui/material/TextField';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Alert from '@mui/material/Alert';

export default function ShoppingCartComponent({rerenderCart}){

    const { user } = useContext(UserContext);
    const [cart, setCart] = useState([]);
    const [totalPrice, setTotalPrice] = useState(0);
    const [order, setOrder] = useState({});
    const [checked, setChecked] = useState(true);
    const [textValue, setTextValue] = useState("");
    const [error, setError] = useState(false);
    const navigate = useNavigate();

    const display = (data) => {
        if(data != ""){
            setChecked(false);
            setTextValue(data);
        }
    }

    useEffect(() => {
        const order = JSON.parse(localStorage.getItem(`${user.username}order`));
        var id = user.id;
        if(id == ''){
            id=null;
        }
        if(!order){
            API.post("Orders", { userId: id })
            .then(res => {
                console.log(res);
                console.log(res.data);
                setOrder(res.data);
                display(res.data.shippingAddress);
                localStorage.setItem(`${user.username}order`, JSON.stringify(res.data.id));
              });
        }
            else{
                API.get(`Orders/${order}`)
                .then(res => {
                    console.log(res);
                    console.log(res.data);
                    setOrder(res.data);
                    console.log(res.data.shippingAddress);
                    display(res.data.shippingAddress);
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

    const checkAddress = () => {
        if(textValue == ""){
            return false
        }
        return true;
    }

    const addItemsToOrder = () => {
        if(checkAddress()){
            const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
            const timer = ms => new Promise(res => setTimeout(res, ms));
            async function load () { 
                for (var i = 0; i < cart.length; i++) {
                    console.log(i);
                    API.post(`OrderItems`, {
                        quantity: cart[i].desiredQuantity,
                        productId: cart[i].id,
                        orderId: order.id
                        }).then(res => {
                            console.log(res);
                            console.log(res.data);
                        });
                  await timer(500); 
                }
            }
            load();
            API.put(`Orders/${order.id}`,{
                price: totalPrice,
                shippingAddress: textValue,
                state: 1
                }).then(res =>{
                    console.log(res);
                });
            localStorage.removeItem(`${user.username}order`);
            localStorage.removeItem(`${user.username}cart`);
            rerenderCart();
            setTimeout(() => {
                navigate("../");
              }, 1000);
        }
        else{
            setError(true);
        }
        
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
        <>
          {error ? <Alert onClose={() => {setError(false);}} severity='error'>Please enter a delivery address before placing the order</Alert> : <></> }
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
                  <div style={{position: "sticky", top: "0"}}>
                      <Typography variant="h4" >
                          Total Price: {' '}{totalPrice}{'\u20AC'}
                          <p>hello: {order.id}</p>
                      </Typography>
                      <TextField id="outlined-basic" 
                          label="Address" 
                          variant="outlined" 
                          value={textValue} 
                          disabled={!checked} 
                          onChange={(event) => setTextValue(event.target.value)} 
                      />
                      <div style={{marginTop: "10px"}}>
                          <FormControlLabel control={
                              <Checkbox checked={checked} 
                                  onChange={(event) => setChecked(event.target.checked)}
                              />} label="Change delivery address" 
                          />
                          <Button variant="contained" 
                              onClick={(event) => addItemsToOrder()}
                              >Place order
                          </Button>
                          <Button variant="contained" onClick={(event) => checkAddress()}> check address</Button>
                          {checked? <p>{textValue}</p> : <p>no</p>}
                      </div>
                  </div>
                        
                        
              </div>
          </div>
        </>
    );
}