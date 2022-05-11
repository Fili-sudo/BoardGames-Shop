import * as React from 'react';
import ImgMediaCard from './MediaCard';
import { useEffect, useState } from "react";
import { styled, alpha } from '@mui/material/styles';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function ProductCards({ products, loading }){

    const [productes, setProducts] = useState(
    [
        {alt: "cat", url: "https://www.thesprucepets.com/thmb/QDw4vt7XXQejL2IRztKeRLow6hA=/2776x1561/smart/filters:no_upscale()/cat-talk-eyes-553942-hero-df606397b6ff47b19f3ab98589c3e2ce.jpg"},
        {alt: "dog", url: "https://cdn.britannica.com/49/161649-050-3F458ECF/Bernese-mountain-dog-grass.jpg"},
        {alt: "bird", url: "https://static.scientificamerican.com/sciam/cache/file/7A715AD8-449D-4B5A-ABA2C5D92D9B5A21_source.png"},
        {alt: "dolphin", url: "https://www.thoughtco.com/thmb/AvVf2u-2pJZC0aQD-kUlv2ESZD4=/5120x2880/smart/filters:no_upscale()/atlantic-bottlenose-dolphin--jumping-high-during-a-dolphin-training-demonstration-154724035-59ce93949abed50011352530.jpg"}
    ]);

    if(loading){
        return(
            <h2>Loading...</h2>
        );
    }
    
    return (
        <div>
            {products.map((product => (
                            <ImgMediaCard 
                                key = {product.id}
                                id = {product.id}
                                alt = {product.productName}
                                image = {product.image}
                                description = {product.description}
                                price = {product.price}
                            />
                        )))}
        </div>
        
    );
}