import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import DenseAppBar from '../components/DenseAppBar';
import Helmet from 'react-helmet';
import API from '../api';
import { useEffect, useState, useContext } from "react";
import { UserContext } from '../services/UserContext';

function createData(name, calories, fat, carbs, protein) {
  return { name, calories, fat, carbs, protein };
}

const rows = [
  createData('Frozen yoghurt', 159, 6.0, 24, 4.0),
  createData('Ice cream sandwich', 237, 9.0, 37, 4.3),
  createData('Eclair', 262, 16.0, 24, 6.0),
  createData('Cupcake', 305, 3.7, 67, 4.3),
  createData('Gingerbread', 356, 16.0, 49, 3.9),
];

export default function MyOrdersComponent() {

  const { user } = useContext(UserContext);
  const [rows, setRows] = useState([]);

  useEffect(()=>{
    console.log(user.username);
    if(user.username!=""){
        API.get(`Authenticate/${user.username}`)
        .then(res => {
            console.log(res.data);
            API.get(`Orders/users/${res.data.id}`)
                .then(res => {
                    console.log(res.data);
                    setRows(res.data);
                });
        });
    }
    

  },[user]);

  const getState = (data) =>{
    switch(data){
        case 0:{
            return "In processing";
        }
        case 1:{
          return "Pending";
        }
        case 2:{
          return "Confirmed";
        }
        case 3:{
          return "Canceled";
        }
        case 4:{
          return "Arrived";
        }
    }
  }

  return (
    <>
        <Helmet bodyAttributes={{style: 'background-color : #EEEEEE'}}/>
         <header>
           <DenseAppBar title={"Your Orders"}/>
         </header>
    
        <div style={{padding: "50px 7% 100px 7%"}}>
            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell align="left">Index</TableCell>
                    <TableCell align="left">Id</TableCell>
                    <TableCell align="right">Price</TableCell>
                    <TableCell align="left">Shipping Address</TableCell>
                    <TableCell align="left">State</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {rows.map((row, index) => (
                    <TableRow
                      key={index}
                      sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {index+1}
                      </TableCell>
                      <TableCell align="left">{row.id}</TableCell>
                      <TableCell align="right">{row.price}</TableCell> 
                      <TableCell align="left">{row.shippingAddress}</TableCell>
                      <TableCell align="left">{getState(row.state)}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
        </div>
    </>
  );
}
 