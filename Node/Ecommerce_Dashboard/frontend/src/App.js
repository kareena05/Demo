import logo from './logo.svg';
import './App.css';
import Navbar from './Navbar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className="App">
    
        <BrowserRouter>
        <Navbar></Navbar> 
        <Routes>
          <Route path='/' element={<h1>Welcome</h1>}></Route>
          <Route path='/contact' element={<h1>Contact page</h1>}></Route>
          <Route path='/products' element={<h1>Products page</h1>}></Route>
        </Routes>
       
        </BrowserRouter>
       
        <h1>Welcome to Easy Commerce</h1>
        
     
    </div>
  );
}

export default App;
