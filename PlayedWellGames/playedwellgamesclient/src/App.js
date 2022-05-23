import logo from './logo.svg';
import './App.css';
import SearchAppBar from './components/SearchAppBar';
import ImgMediaCard from './components/MediaCard';
import ProductCards from './components/ProductCards';
import BasicPagination from './components/Pagination';
import SelectFilled from './components/Select';
import { useEffect, useState } from "react";
import axios from 'axios';
import { Route, Routes, useParams } from 'react-router-dom';
import HomeComponent from './pages/HomeComponent';
import RouterComponent from './components/RouterComponent';
import ProductDetailsComponent from './pages/ProductDetailsComponent'
import RegisterFormComponent from './pages/RegisterFormComponent';
import LoginFormComponent from './pages/LoginFormComponent';
import ShoppingCartComponent from './pages/ShoppingCartComponent';
import MyCard from './components/MyCard';
import PrivateRoute from './components/PrivateRoute';
import OnlyAuthenticatedRoute from './pages/OnlyAdminPage';
import OnlyAdminPage from './pages/OnlyAdminPage';

function App() {

  const [changedCart, setChangedCart] = useState(false);

  const changeCart = () => {
    setChangedCart(!changedCart);
  }
  
  return (
    <div>
      <Routes>
        <Route path="/admin-page" 
              element = {
              <PrivateRoute>
                <OnlyAdminPage/>
              </PrivateRoute>
            }/>
        <Route path="/" element = {<HomeComponent modifiedCart={changedCart}/>}/>
        <Route path="/Go" element = {<RouterComponent/>}/>
        <Route path="/product-details/:id" element = {<ProductDetailsComponent/>}/>
        <Route path="/register-user" element = {<RegisterFormComponent/>}/>
        <Route path="/login" element = {<LoginFormComponent/>}/>
        <Route path="/shopping-cart" element = {<ShoppingCartComponent rerenderCart={changeCart}/>}/>
      </Routes>

      
    </div>
    
    
  );
}

export default App;
