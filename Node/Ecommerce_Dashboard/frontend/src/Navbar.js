import React from "react";
import {Link} from "react-router-dom";
const Navbar = ()=>{
    return(<div>
        <ul className="nav-ul">
            <li><Link to= "/" >Home</Link></li>
            <li><Link to= "/contact" >Contact</Link></li>
            <li><Link to= "/add" >Add Product</Link></li>
            <li><Link to= "/update" >Update Product</Link></li>
            <li><Link to= "/profile" >Profile</Link></li>
            <li><Link to= "/logout" >Logout</Link></li>
        </ul>
    </div>);
}
export default Navbar;