import * as React from 'react';
import Alert from '@mui/material/Alert';
import SearchAppBar from '../components/SearchAppBar';
import ImgMediaCard from '../components/MediaCard';
import ProductCards from '../components/ProductCards';
import BasicPagination from '../components/Pagination';
import SelectFilled from '../components/Select';
import { useEffect, useState, useContext } from "react";
import { UserContext } from '../services/UserContext';
import axios from 'axios';
import API from '../api';
import { Route, Routes } from 'react-router-dom';


export default function HomeComponent({modifiedCart}){

  const [products, setProducts] = useState([]);
  const [filteredProducts, SetFilteredProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [productsPerPage, SetproductsPerPage] = useState(5);
  const [orderByState, SetOrderByState] = useState("");
  const [changedOrderRule, SetChangedOrderRule] = useState(true);
  const [addedToCartAlert, setAddedToCartAlert] = useState(false);
  const [errorAtCartAlert, setErrorAtCartAlert] = useState(false);
  const [emptyCartAlert, setemptyCartAlert] = useState(false);
  const [alertContent, setAlertContent] = useState('');
  const [count, setCount] = useState(0);
  const [changedCart, setChangedCart] = useState(modifiedCart);
  const [order, setOrder] = useState({});

  const { user, logout } = useContext(UserContext);

  useEffect(() => {
    const fetchProducts = async () => {
      setLoading(true);
      const res = await API.get('Products');
      setProducts(res.data);
      SetFilteredProducts(res.data.slice());
      setLoading(false);
    };

    //localStorage.clear();
    //console.log(user);
    //logout();
    fetchProducts();
  }, []);
  useEffect(() => {
    const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
    if(cart){ 
      setCount(cart.length);
    }
      else{
        setCount(0);
      }
  }, [user, changedCart]);

  const emptyCart = () =>{
    setemptyCartAlert(true);
    setAlertContent("You don't have any products in your cart");
  }

  const addToCart2 = (product) => {
    const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
    if(cart == null){
      let productArray = [];
      productArray.push(product);
      localStorage.setItem(`${user.username}cart`, JSON.stringify(productArray));
      setAlertContent("Product added successfully to your cart");
      setAddedToCartAlert(true);
      setCount(productArray.length);
    }
    else{
      let productArray = cart;
      if(productArray.find((arrayProduct) => { return arrayProduct.id === product.id })){
        setAlertContent("This product is already in your cart");
        setErrorAtCartAlert(true);
        console.log("item already in cart");
      }
      else {
        productArray.push(product);
        localStorage.setItem(`${user.username}cart`, JSON.stringify(productArray));
        setAlertContent("Product added successfully to your cart");
        setAddedToCartAlert(true);
        setCount(productArray.length);
      }
    }
  }

  const paginate = pageNumber => setCurrentPage(pageNumber)
  const orderRule = rule => { SetOrderByState(rule); SetChangedOrderRule(false); }
  const itemsOnPage = nr => { SetproductsPerPage(nr); }
  const updateProducts = () => {
    if(orderByState == "By price" && !changedOrderRule){
      SetChangedOrderRule(true);
      SetFilteredProducts(filteredProducts.sort((a, b) => a.price <= b.price? -1: 1 ))
    }
    else if (orderByState == "Alphabetically" && !changedOrderRule){
      SetChangedOrderRule(true);
      SetFilteredProducts(filteredProducts.sort((a, b) => a.productName <= b.productName? -1: 1 ))
    }
    else if (!changedOrderRule){ 
      SetChangedOrderRule(true);
      SetFilteredProducts(products.slice());
    }
  }
  
  updateProducts();
  const indexOfLastProduct = currentPage * productsPerPage;
  const indexOfFirstProduct = indexOfLastProduct - productsPerPage;
  const currentProducts = filteredProducts.slice(indexOfFirstProduct, indexOfLastProduct);

  

  return (
    <div>
      <header>
        <h1>
          Played Well Games
        </h1>
        <SearchAppBar count = {count} emptyCart={emptyCart}/>
      </header>
      {errorAtCartAlert ? <Alert onClose={() => {setErrorAtCartAlert(false);}} severity='error'>{alertContent}</Alert> : <></> }
      {emptyCartAlert ? <Alert onClose={() => {setemptyCartAlert(false);}} severity='error'>{alertContent}</Alert> : <></> }
      {addedToCartAlert ? <Alert onClose={() => {setAddedToCartAlert(false);}} severity='success'>{alertContent}</Alert> : <></> }
      <SelectFilled orderRule = {orderRule} itemsOnPage = {itemsOnPage} />
      <ProductCards products={currentProducts} loading={loading} addToCart={addToCart2}/>
      <BasicPagination
        productsPerPage = {productsPerPage}
        totalProducts = {products.length}
        paginate = {paginate}
      />
    </div>
    
    
  );
}