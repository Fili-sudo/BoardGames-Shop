import React from "react";
import { Route, Routes } from 'react-router-dom';
import { Link, NavLink } from 'react-router-dom';
import ProductsPageComponent from './ProductsPageComponent';
import AdminAppBar from "../components/AdminAppBarComponent";
import OrdersPageComponent from "./OrdersPageComponent";
import UpdateProductComponent from "./UpdateProductComponent";
import AddProductComponent from "./AddProductComponent";
import BasicTable from "./OrderDetailsComponent";

export default function OnlyAdminPage(){

    return(
        <>
        <header>
            <AdminAppBar/>
        </header>

        
        <Routes>
            <Route path="/products" element = {<ProductsPageComponent/>}/>
            <Route path="/products/update/:id" element = {<UpdateProductComponent/>}/>
            <Route path="/products/new-product" element = {<AddProductComponent/>}/>
            <Route path="/orders" element = {<OrdersPageComponent/>}/>
            <Route path="/orders/:id" element = {<BasicTable/>}/>
        </Routes>
        </>
    );
}