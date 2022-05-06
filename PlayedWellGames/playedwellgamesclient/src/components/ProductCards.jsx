import * as React from 'react';
import ImgMediaCard from './MediaCard';
import { useEffect, useState } from "react";
import { styled, alpha } from '@mui/material/styles';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function ProductCards(){

    const [products, setProducts] = useState([
        {alt: "cat", url: "https://www.thesprucepets.com/thmb/QDw4vt7XXQejL2IRztKeRLow6hA=/2776x1561/smart/filters:no_upscale()/cat-talk-eyes-553942-hero-df606397b6ff47b19f3ab98589c3e2ce.jpg"},
        {alt: "dog", url: "https://cdn.britannica.com/49/161649-050-3F458ECF/Bernese-mountain-dog-grass.jpg"},
        {alt: "bird", url: "https://static.scientificamerican.com/sciam/cache/file/7A715AD8-449D-4B5A-ABA2C5D92D9B5A21_source.png"},
        {alt: "dolphin", url: "https://www.thoughtco.com/thmb/AvVf2u-2pJZC0aQD-kUlv2ESZD4=/5120x2880/smart/filters:no_upscale()/atlantic-bottlenose-dolphin--jumping-high-during-a-dolphin-training-demonstration-154724035-59ce93949abed50011352530.jpg"}
    ]);


    return (
        <div>
            <FormControl variant="filled" sx={{ m: 1, minWidth: 120 }}>
                <InputLabel id="demo-simple-select-label">Order by</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    label="Age"
                >
                <MenuItem value={0}>Aphabetically</MenuItem>
                <MenuItem value={1}>Price</MenuItem>
                </Select>
            </FormControl>
            <br />
            {products.map(((product, key) => (
            <ImgMediaCard 
                key = {key}
                alt = {product.alt}
                image = {product.url}
            />
            )))}
        </div>
        
    );
}