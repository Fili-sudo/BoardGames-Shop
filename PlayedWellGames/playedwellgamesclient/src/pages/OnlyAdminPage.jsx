import React from "react";
import { Route, Routes } from 'react-router-dom';
import { Link } from 'react-router-dom';
import ProductsPageComponent from './ProductPageComponent';

export default function OnlyAdminPage(){

    return(
        <>
        <h1>You have entered an only admin user page</h1>

        <nav>
        <Link to="Go">Go</Link>
        </nav>
        <Routes>
            <Route path="/Go" element = {<ProductsPageComponent/>}/>
        </Routes>
        </>
    );
}