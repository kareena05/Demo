import React from "react";
import { Link, useNavigate } from "react-router-dom";
const Navbar = () => {
    const mylogo = require("../mylogo.svg");
    const localdata = localStorage.getItem("user");
    const navigate = useNavigate();
    const LogOut = () => {
        localStorage.clear();
        navigate("/signup")
    }
    return (<div>
<img src={mylogo} alt="logo" className="mylogo" />
        {localdata ?
            <ul className="nav-ul">
                <li><Link to="/" >Home</Link></li>
                <li><Link to="/contact" >Contact</Link></li>
                <li><Link to="/addProducts" >Add Product</Link></li>               
                <li><Link to="/profile" >Profile</Link></li>
                <li><Link onClick={LogOut} to="/signup" >Logout</Link></li>

            </ul> :
            <ul className="nav-ul nav-right">
                <li><Link to="/signup" >Signup</Link></li>
                <li><Link to="/login" >Login</Link></li>

            </ul>
        }



    </div>);
}
export default Navbar;