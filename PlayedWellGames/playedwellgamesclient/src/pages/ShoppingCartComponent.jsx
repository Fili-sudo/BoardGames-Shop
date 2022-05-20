import * as React from 'react';
import MyCard from "../components/MyCard"
import { useEffect, useState, useContext  } from "react";
import { UserContext } from '../services/UserContext';

export default function ShoppingCartComponent(){

    const { user } = useContext(UserContext);
    const [cart, setCart] = useState([]);

    useEffect(() => {
        const cart = JSON.parse(localStorage.getItem(`${user.username}cart`));
        setCart(cart);
    },[user]);


    return(
        <div>
            {cart.map((item => (
                            <MyCard 
                                key={item.id}
                                image={item.image} 
                                productName={item.productName}
                                quantity={item.quantity}
                                desiredQuantity={item.desiredQuantity}
                                price={item.price}
                            />
                        )))}
        </div>
    );
}