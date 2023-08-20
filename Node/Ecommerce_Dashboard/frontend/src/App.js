import React from 'react';
import logo from './logo.svg';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Footer from './components/Footer';
import SignUp from './components/Signup';
import Login from './components/Login';
import PrivateComponent from './components/PrivateComponent';

function App() {
  const localdata = localStorage.getItem("user");
  return (
    <div className="App">
    
        <BrowserRouter>
        <Navbar></Navbar> 
        <Routes>
        <Route  element={<PrivateComponent/>}>
          <Route path='/' element={<h1>Welcome to Easy Commerce  {localdata?  JSON.parse(localdata).data.fullname:""}</h1>}></Route>
          <Route path='/contact' element={<h1>Contact page</h1>}></Route>
          <Route path='/products' element={<h1>Products page</h1>}></Route>
          </Route>
          <Route path="/signup" element={<SignUp/>}></Route>
          <Route path="/login" element={<Login/>}></Route>

        </Routes>
        
        
       
        </BrowserRouter>
       
    
        
     <Footer></Footer>
    </div>
  );
}

export default App;
