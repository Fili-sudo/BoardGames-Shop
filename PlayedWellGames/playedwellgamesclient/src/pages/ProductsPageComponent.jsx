import * as React from 'react';
import { useEffect, useState } from "react";
import axios from 'axios';
import { Outlet  } from "react-router-dom";
import EnhancedTable from "../components/TableComponent"

export default function ProductsPageComponent(){

    return (
        <div>
            <h1>Products Page</h1>
            <div style={{padding: "20px"}}>
                <EnhancedTable/>
            </div>
        </div>
    );
}