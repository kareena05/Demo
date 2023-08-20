import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
useEffect(()=>{
    const localdata = localStorage.getItem("user");
    if(localdata){
        navigate("/");
    }
})

    const navigate = useNavigate();
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");
    const display = async()=>{
       let result = await fetch("http://localhost:5000/login",{
       "method":"POST",
       "body": JSON.stringify({email,password}),
       "headers":{
        "Content-Type":"application/json"
       }
    
       });
       result =await result.json();
       console.log(result);
       if(result.success==true && result.data.fullname){
        localStorage.setItem("user",JSON.stringify(result));
        navigate("/");
       }else{
        alert(result.message);
       }
    }
    return (
        <div className='signup-container login-container'>
            <h3 className="signup-heading"> Login</h3>
            
            <input type="text" name="email" className="inputs" placeholder="Enter email" value={email} onChange={(e) => setEmail(e.target.value)} />
            <input type="text" name="password" className="inputs" placeholder="Enter password" value={password} onChange={(e) => setPassword(e.target.value)} />
            <input type="submit" onClick={display} value="Login" className="signup-btn" ></input>
        </div>
    );
}
export default Login;