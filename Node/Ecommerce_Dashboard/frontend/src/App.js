import React from 'react';
import logo from './logo.svg';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Footer from './components/Footer';
import SignUp from './components/Signup';
import Login from './components/Login';
import PrivateComponent from './components/PrivateComponent';
import Products from './components/Products';
import ProductList from './components/ProductList';
import UpdateProduct from './components/UpdateProduct';

function App() {
  const localdata = localStorage.getItem("user");
  return (
    <div className="App">
    
        <BrowserRouter>
        <Navbar></Navbar> 
        <Routes>
        <Route  element={<PrivateComponent/>}>
          <Route path='/' element={<ProductList />}></Route>
          <Route path='/contact' element={<h1>Contact page</h1>}></Route>
          <Route path='/addProducts' element={<Products />}></Route>
          <Route path='/updateProduct/:id' element={<UpdateProduct />}></Route>
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
