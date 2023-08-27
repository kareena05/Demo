import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Products = () => {
    const navigate = useNavigate();
    const [productName,setproductName] = useState("");
    const [category,setcategory] = useState("");
    const [company,setcompany] = useState("");
    const [price,setprice] = useState("");
    const [error,seterror] = useState(false);



    const display = async()=>{
        if( !productName || !category || !company || !price){
            seterror(true);
            //return false;            
        }

       
        console.log(productName,category,company,price);
        let userId = JSON.parse(localStorage.getItem("user")).data._id;
        console.log(userId);
        let result = await fetch("http://localhost:5000/AddProduct",{
       "method":"POST",
       "body": JSON.stringify({productName,category,company,price,userId}),
       "headers":{
        "Content-Type":"application/json"
       }
       });
       result = await result.json();
       console.log(result);
       alert(result.message);
    }
    return (
        <div className='add-product-container'>
            <h3 className="signup-heading"> Add Product</h3>
            
        { error && !productName  ? <span className="error-span"> Enter product name </span>: ""}
            <input type="text" className="inputs" placeholder="Enter Product name" value={productName} onChange={(e) => setproductName(e.target.value)} />

            { error && !category  ? <span className="error-span"> Enter category name </span>: ""}
            <input type="text"  className="inputs" placeholder="Enter category name" value={category} onChange={(e) => setcategory(e.target.value)} />

            { error && !company  ? <span className="error-span"> Enter company name </span>: ""}
            <input type="text"  className="inputs" placeholder="Enter company name" value={company} onChange={(e) => setcompany(e.target.value)} />

            { error && !price  ? <span className="error-span"> Enter price </span>: ""}
            <input type="text"  className="inputs" placeholder="Enter price " value={price} onChange={(e) => setprice(e.target.value)} />

            <input type="submit" onClick={display} value="Add Product" className="btn" ></input>
        </div>
    );
}
export default Products;