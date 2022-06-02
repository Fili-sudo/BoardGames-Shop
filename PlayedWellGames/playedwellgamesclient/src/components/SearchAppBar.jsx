import * as React from 'react';
import { styled, alpha } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import InputBase from '@mui/material/InputBase';
import MenuIcon from '@mui/icons-material/Menu';
import SearchIcon from '@mui/icons-material/Search';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import Button from '@mui/material/Button';
import Badge from '@mui/material/Badge';
import { Link } from 'react-router-dom';
import { useEffect, useState, useContext } from "react";
import { UserContext } from '../services/UserContext';
import LoginIcon from '@mui/icons-material/Login';
import LogoutIcon from '@mui/icons-material/Logout';


const Search = styled('div')(({ theme }) => ({
  position: 'relative',
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  '&:hover': {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginLeft: 0,
  width: '100%',
  [theme.breakpoints.up('sm')]: {
    marginLeft: theme.spacing(1),
    width: 'auto',
  },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: '100%',
  position: 'absolute',
  pointerEvents: 'none',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: 'inherit',
  '& .MuiInputBase-input': {
    padding: theme.spacing(1, 1, 1, 0),
    // vertical padding + font size from searchIcon
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create('width'),
    width: '100%',
    [theme.breakpoints.up('sm')]: {
      width: '12ch',
      '&:focus': {
        width: '20ch',
      },
    },
  },
}));



export default function SearchAppBar(props) {

  const { user, login, logout } = useContext(UserContext);
  const [search, setSearch] = useState("");

  const printSearch = (event) =>{
    console.log(event.target.value);
    props.filter(event.target.value);
  }
  
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          {user.username == ''?<>
            <Link to={`/login`}>
                <Button variant="contained" sx={{marginRight: "10px"}} startIcon={<LoginIcon/>}>
                  Login
                </Button>
            </Link>
          </>:<>
            <Button variant="contained" onClick={() => logout()} sx={{marginRight: "10px"}} endIcon={<LogoutIcon/>}>
              Logout
            </Button>
          </>}
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' } }}
          >
           {user.username!=""? "Welcome, " + user.username: <></>} 
          </Typography>
          <Typography
            variant="h5"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' } }}
          >
           Played Well Games
          </Typography>
          {props.count?
            <>
              <Link to={`/shopping-cart`}>
                <Button variant="contained" startIcon={
                  <Badge color="secondary" badgeContent={props.count}>
                    <ShoppingCartIcon />
                </Badge>}>
                  Shopping Cart
                </Button>
              </Link>
            </>:<>
                <Button variant="contained" onClick={(event) => props.emptyCart()} startIcon={
                  <Badge color="secondary" badgeContent={props.count}>
                    <ShoppingCartIcon />
                  </Badge>}>
                  Shopping Cart
                </Button>
            </>}
          <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder="Search…"
              inputProps={{ 'aria-label': 'search' }}
              onChange={(event) => printSearch(event)}
            />
          </Search>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
