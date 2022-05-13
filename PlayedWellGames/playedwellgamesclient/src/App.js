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
import HomeComponent from './components/HomeComponent';
import RouterComponent from './components/RouterComponent';
import ProductDetailsComponent from './components/ProductDetailsComponent'

function App() {

  
  return (
    <div>
      <Routes>
        <Route path="/" element = {<HomeComponent/>}/>
        <Route path="/Go" element = {<RouterComponent/>}/>
        <Route path="/product-details/:id" element = {<ProductDetailsComponent/>}/>
      </Routes>

      
    </div>
    
    
  );
}

export default App;
