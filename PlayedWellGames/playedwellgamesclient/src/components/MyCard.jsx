import * as React from 'react';
import { Typography } from '@mui/material';
import { useEffect, useState, useContext } from "react";
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import ClearIcon from '@mui/icons-material/Clear';
import Button from '@mui/material/Button';
import ButtonGroup from '@mui/material/ButtonGroup';
import IconButton from '@mui/material/IconButton';
import { UserContext } from '../services/UserContext';


export default function MyCard(props){

    const { user } = useContext(UserContext);
    const [dsrQuantity, setDsrQuantity] = useState(props.desiredQuantity);
    const [display, setDisplay] = useState(true);
    const [noImage] = useState("https://img.freepik.com/free-vector/children-playing-board-game-white-background_1308-94390.jpg?w=2000");

    const changeDesiredQuantity = (dsrQuantity) =>{
      let cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
      let i = cart.findIndex((arrayProduct) => { return arrayProduct.id === props.id });
      cart[i].desiredQuantity = dsrQuantity;
      localStorage.setItem(`${user.username}cart`, JSON.stringify(cart));
    }

    const updateAmount = (in_dec) =>{
        if(dsrQuantity + in_dec != 0 && dsrQuantity + in_dec <= props.quantity){
            setDsrQuantity(dsrQuantity + in_dec);
            props.modify(props.price*(in_dec));
            changeDesiredQuantity(dsrQuantity + in_dec);
        }
      }
    const deleteItem = () =>{
        let cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
        setDisplay(false);
        props.modify(-props.price*dsrQuantity);
        for( var i = 0; i < cart.length; i++){ 
            if ( cart[i].id == props.id) { 
                cart.splice(i, 1); 
            }
        }
        localStorage.setItem(`${user.username}cart`, JSON.stringify(cart));
        console.log(cart);
        props.rerender();
    }

    const CardContainer = {
        padding: "20px",
        margin: "20px", 
        
        display: "flex",
        boxShadow: "3px 3px 10px 0 black", 
        borderRadius:"10px"
    }

    return(
        <>
            {display ?
                <div style={CardContainer}>
                    <div style={{display: "inline-block", maxHeight: "150px", width: "50%"}}>
                      <img src={props.image!=""? props.image : noImage} 
                           alt="image"
                           style={{ width:"100%",
                                    height:"100%",
                                    objectFit:"contain",
                                  }}
                      />
                    </div>
                    <div style={{flex: "1", textAlign: "right"}}>
                      <Typography variant="h4" >
                        {props.productName}
                      </Typography>
                              
                      <Typography variant="h5" sx={{display: "inline", margin: "5px"}}>
                        Desired quantity: {' '}{dsrQuantity}
                      </Typography>
                      <ButtonGroup size="small" variant="contained" aria-label="outlined primary button group" orientation="vertical" >
                        <IconButton onClick={(event) => updateAmount(1)}>
                          <KeyboardArrowUpIcon/>
                        </IconButton>
                        <IconButton onClick={(event) => updateAmount(-1)}>
                          <KeyboardArrowDownIcon/>
                        </IconButton>
                      </ButtonGroup>
                      <Typography variant="h5">
                        Price: {' '}{props.price*dsrQuantity}{'\u20AC'}
                      </Typography>
                      <IconButton color="error" onClick={(event) => deleteItem()}>
                          <ClearIcon/>
                      </IconButton>
                              
                    </div>
                              
                </div>
            : <></>}
        </>
    )
}