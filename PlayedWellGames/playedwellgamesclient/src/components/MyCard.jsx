import * as React from 'react';
import { Typography } from '@mui/material';
import { useEffect, useState } from "react";
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import ClearIcon from '@mui/icons-material/Clear';
import Button from '@mui/material/Button';
import ButtonGroup from '@mui/material/ButtonGroup';
import IconButton from '@mui/material/IconButton';


export default function MyCard(props){

    const [price, setPrice] = useState(props.price);
    const [dsrQuantity, setDsrQuantity] = useState(props.desiredQuantity);
    const [display, setDisplay] = useState(true);

    const updateAmount = (in_dec) =>{
        if(dsrQuantity + in_dec != 0 && dsrQuantity + in_dec <= props.quantity){
            setDsrQuantity(dsrQuantity + in_dec);
            props.modify(props.price*(in_dec));
        }
      }
    const deleteItem = () =>{
        setDisplay(false);
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
                      <img src={props.image} 
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
                        Price: {' '}{price*dsrQuantity}{'\u20AC'}
                      </Typography>
                      <IconButton onClick={(event) => deleteItem()}>
                          <ClearIcon/>
                      </IconButton>
                              
                    </div>
                              
                </div>
            : <></>}
        </>
    )
}