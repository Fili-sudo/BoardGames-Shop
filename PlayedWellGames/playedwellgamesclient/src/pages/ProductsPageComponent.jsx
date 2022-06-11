import * as React from 'react';
import { useEffect, useState } from "react";
import axios from 'axios';
import { Outlet  } from "react-router-dom";
import EnhancedTable from "../components/TableComponent"

export default function ProductsPageComponent(){

    return (
        <div>
            <div style={{padding: "50px 7% 0 7%"}}>
                <EnhancedTable/>
            </div>
        </div>
    );
}