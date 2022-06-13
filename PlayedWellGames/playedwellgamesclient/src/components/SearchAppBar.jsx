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
import { useNavigate } from "react-router-dom";
import LoginIcon from '@mui/icons-material/Login';
import LogoutIcon from '@mui/icons-material/Logout';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';


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
  const navigate = useNavigate();

  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

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
            <Box sx={{ display: { xs: 'none', sm: 'none', md: "none", lg: "inline-flex"}}}>
              <Button variant="contained" onClick={() => logout()} sx={{marginRight: "10px"}} endIcon={<LogoutIcon/>}>
                Logout
              </Button>
              <Link to={`/my-orders`}>
                  <Button variant="contained" sx={{marginRight: "10px"}}>
                    Your Orders
                  </Button>
              </Link>
            </Box>
            <Box sx={{ display: { xs: 'inline-flex', sm: 'inline-flex', md: "inline-flex", lg: "none"}}}>
              <IconButton
                id="basic-button"
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                onClick={handleClick}
              >
                <MenuIcon />
              </IconButton>
              <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                  'aria-labelledby': 'basic-button',
                }}
              >
                <MenuItem onClick={() => {handleClose(); navigate(`./my-orders`);}}>Your Orders</MenuItem>
                <MenuItem onClick={() => {handleClose(); logout()}}>Logout</MenuItem>
              </Menu>
            </Box>
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
            sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' }, fontWeight: "700"}}
          >
           Played Well Games
          </Typography>
          {props.count?
            <>
              <Link to={`/shopping-cart`}>
                <Box sx={{ display: { xs: 'none', sm: 'none', md: "inline-flex", lg: "inline-flex"}}}>
                  <Button variant="contained" startIcon={
                    <Badge color="secondary" badgeContent={props.count}>
                      <ShoppingCartIcon />
                  </Badge>}>
                    Shopping Cart
                  </Button>
                </Box>
                <Box sx={{ display: { xs: 'inline-flex', sm: 'inline-flex', md: "none", lg: "none"}}}>
                  <Button variant="contained" startIcon={
                    <Badge color="secondary" badgeContent={props.count}>
                      <ShoppingCartIcon />
                    </Badge>}>
                  </Button>
                </Box>
              </Link>
            </>:<>
                <Box sx={{ display: { xs: 'none', sm: 'none', md: "inline-flex", lg: "inline-flex"}}}>
                  <Button variant="contained" onClick={(event) => props.emptyCart()} startIcon={
                    <Badge color="secondary" badgeContent={props.count}>
                      <ShoppingCartIcon />
                    </Badge>}>
                    Shopping Cart
                  </Button>
                </Box>
                <Box sx={{ display: { xs: 'inline-flex', sm: 'inline-flex', md: "none", lg: "none"}}}>
                  <Button variant="contained" onClick={(event) => props.emptyCart()} startIcon={
                    <Badge color="secondary" badgeContent={props.count}>
                      <ShoppingCartIcon />
                    </Badge>}>
                  </Button>
                </Box>
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
