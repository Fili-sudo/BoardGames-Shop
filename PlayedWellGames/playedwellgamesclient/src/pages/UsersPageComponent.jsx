import * as React from 'react';
import { useEffect, useState } from "react";
import axios from 'axios';
import { Outlet  } from "react-router-dom";
import EnhancedTable from '../components/TableForUsersComponent';

export default function UsersPageComponent(){

    return (
        <div>
            <h1>Users Page</h1>
            <div style={{padding: "20px"}}>
                <EnhancedTable/>
            </div>
        </div>
    );
}