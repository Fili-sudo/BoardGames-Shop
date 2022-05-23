import React from "react";
import { Route, Routes } from 'react-router-dom';
import { Link, NavLink } from 'react-router-dom';
import ProductsPageComponent from './ProductsPageComponent';
import AdminAppBar from "../components/AdminAppBarComponent";
import OrdersPageComponent from "./OrdersPageComponent";

export default function OnlyAdminPage(){

    return(
        <>
        <header>
            <AdminAppBar/>
        </header>

        
        <Routes>
            <Route path="/products" element = {<ProductsPageComponent/>}/> 
            <Route path="/orders" element = {<OrdersPageComponent/>}/>
        </Routes>
        </>
    );
}