import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";



const SignUp = () => {
const [fullname,setFullname] = useState("");
const [email,setEmail] = useState("");
const [password,setPassword] = useState("");

const navigate = useNavigate();
useEffect(()=>{
    const localdata = localStorage.getItem("user");
    if(localdata){
        navigate("/")
    }
})

const display = async () => {
    console.log(fullname, email, password);
    let result = await fetch("http://localhost:5000/signup", {
        method: "POST",
        body: JSON.stringify({ fullname, email, password }), // Wrap the data in an object
        headers: {
            'Content-Type': 'application/json' 
        },
    });
    result = await result.json();
    console.log(result);
    localStorage.setItem("user",JSON.stringify(result));
    navigate('/');
}

    return (
        <div className="signup-container">
            <h3 className="signup-heading"> Sign Up</h3>
            <input type="text" name="fullname" className="inputs" placeholder="Enter Fullname" value={fullname} onChange={(e)=>setFullname(e.target.value)}/>
            <input type="text" name="email" className="inputs" placeholder="Enter email"  value={email} onChange={(e)=>setEmail(e.target.value)}/>
            <input type="text" name="password" className="inputs" placeholder="Enter password" value={password} onChange={(e)=>setPassword(e.target.value)}/>

            <input type="submit" value="SignUp" className="signup-btn" onClick={display}></input>

        </div>
    );
}
export default SignUp;