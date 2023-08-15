import React from 'react';
import {Navigate, Outlet} from 'react-router-dom';


const PrivateComponent = ()=>{
    const localdata = localStorage.getItem("user");
    if(localdata){
        return (
            <Outlet/>
        );
    } else{
        return (
          <Navigate to="/signup" />
        );
    }
   
}
export default PrivateComponent;