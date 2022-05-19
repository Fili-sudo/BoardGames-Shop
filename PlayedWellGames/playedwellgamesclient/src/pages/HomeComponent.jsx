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


export default function HomeComponent(){

  const [products, setProducts] = useState([]);
  const [filteredProducts, SetFilteredProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [productsPerPage, SetproductsPerPage] = useState(5);
  const [orderByState, SetOrderByState] = useState("");
  const [changedOrderRule, SetChangedOrderRule] = useState(true);
  const [order, SetOrder] = useState(0);
  const [addedToCartAlert, setAddedToCartAlert] = useState(false);
  const [errorAtCartAlert, setErrorAtCartAlert] = useState(false);
  const [alertContent, setAlertContent] = useState('');

  const { user, logout } = useContext(UserContext);

  useEffect(() => {
    const order = JSON.parse(localStorage.getItem('order'));
    if (order) {
      console.log("localStorageExists");
      SetOrder(order);
    }
      else{
        localStorage.setItem('order', JSON.stringify(0));
      }
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


  //const addItemToCart = (productId) => {
  //  API.post('OrderItems', {
  //    quantity: "1",
  //    productId: productId,
  //    orderId: order
  //  }).then(res => {
  //    console.log(res.data);
  //  })
  //}


  //const addToCart = async (productId) => {
  //  if(order == 0){
  //    const res = await axios.post("https://localhost:7020/api/Orders", { userId: null });
  //    SetOrder(res.data.id);
  //    localStorage.setItem('order', JSON.stringify(res.data.id));
  //    console.log(res);
  //    //addItemToCart(res.data.id);
  //  }
  //  else{
  //    if(user.username == ""){
  //      console.log("no user logged");
  //      //addToCart2({id: 1, name: "joc"});
  //    }
  //      else{
  //        console.log("user logged");
  //      }
  //    console.log("not run");
  //    //addItemToCart(productId);
  //  }
  //}
  const addToCart2 = (product) => {
    const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
    if(cart == null){
      let productArray = [];
      productArray.push(product);
      localStorage.setItem(`${user.username}cart`, JSON.stringify(productArray));
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
        <SearchAppBar/>
      </header>
      {errorAtCartAlert ? <Alert onClose={() => {setErrorAtCartAlert(false);}} severity='error'>{alertContent}</Alert> : <></> }
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