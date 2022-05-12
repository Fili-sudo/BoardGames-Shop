import * as React from 'react';
import SearchAppBar from './SearchAppBar';
import ImgMediaCard from './MediaCard';
import ProductCards from './ProductCards';
import BasicPagination from './Pagination';
import SelectFilled from './Select';
import { useEffect, useState } from "react";
import axios from 'axios';
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

  useEffect(() => {
    const fetchPosts = async () => {
      setLoading(true);
      const res = await axios.get('https://localhost:7020/api/Products');
      setProducts(res.data);
      SetFilteredProducts(res.data.slice());
      setLoading(false);
    };

    fetchPosts();
  }, []);



  const addToCart = () => {
    if(order == 0){
      axios.post("https://localhost:7020/api/Orders", { userId: null })
      .then(res => {
        console.log(res);
        console.log(res.data);
      })
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
      <SelectFilled orderRule = {orderRule} itemsOnPage = {itemsOnPage} />
      <ProductCards products={currentProducts} loading={loading} />
      <BasicPagination
        productsPerPage = {productsPerPage}
        totalProducts = {products.length}
        paginate = {paginate}
      />
    </div>
    
    
  );
}