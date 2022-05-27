import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { Link, NavLink } from 'react-router-dom';

export default function AdminAppBar() {

    let activeStyle = {
        textDecoration: "none",
        color: "#FAF9F6",
        backgroundColor: "#d27219",
        fontSize: "20px",
        fontWeight: "700",
        display: "inline-block",
        margin: "20px",
        padding: "10px",
        borderRadius: "10px"
      };
    let unactiveStyle = {
        textDecoration: "none",
        color: "#FAF9F6",
        fontSize: "20px",
        fontWeight: "700",
        display: "inline-block",
        margin: "20px",
        padding: "10px",
        borderRadius: "10px"
    }

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar sx={{justifyContent: "center"}}>
          <NavLink to="products" style={({isActive}) => isActive? activeStyle: unactiveStyle}>
              Products
          </NavLink>
          <NavLink to="orders" style={({isActive}) => isActive? activeStyle: unactiveStyle}>
              Orders
          </NavLink>
          <NavLink to="users" style={({isActive}) => isActive? activeStyle: unactiveStyle}>
              Users
          </NavLink>
          
        </Toolbar>
      </AppBar>
    </Box>
  );
}
