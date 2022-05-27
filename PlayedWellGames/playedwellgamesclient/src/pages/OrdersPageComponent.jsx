import * as React from 'react';
import { useEffect, useState } from "react";
import axios from 'axios';
import { Outlet  } from "react-router-dom";
import EnhancedTable from "../components/TableForOrdersComponent"

export default function ProductsPageComponent(){

    return (
        <div>
            <h1>Orders Page</h1>
            <div style={{padding: "20px"}}>
                <EnhancedTable/>
            </div>
        </div>
    );
}