import * as React from 'react';
import { useParams } from 'react-router-dom';

export default function ProductDetailsComponent(){

    const { id } = useParams();

    return(
        <h1>Product Details for product with id= {id}</h1>
    );
}