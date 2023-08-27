import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

const UpdateProduct = () => {
    const navigate = useNavigate();
    const [productName,setproductName] = useState("");
    const [category,setcategory] = useState("");
    const [company,setcompany] = useState("");
    const [price,setprice] = useState("");
    const [error,seterror] = useState(false);
    const params = useParams();
  
    useEffect(()=>{
        console.log(params);
        getProductDetails();
    },[])

const getProductDetails=async()=>{
    let result = await fetch(`http://localhost:5000/getProduct/${params.id}`);
    result = await result.json();
    if(result){
        setproductName(result.productName);
        setprice(result.price); 
        setcategory(result.category);
        setcompany(result.company);
    }
    console.warn(result);
}
    const display = async()=>{
        if( !productName || !category || !company || !price){
            seterror(true);
            //return false;
        }

        let result = await fetch(`http://localhost:5000/updateProduct/${params.id}`,{
            method:"PUT",
            body:JSON.stringify({productName,category,price,company}),
            headers:{
                "Content-Type":"application/json"
            }
        });
        result = await result.json();
        alert(result.message);
        if(result.status == true){
            navigate("/");
        }

       
        console.log(productName,category,company,price);
        
    }
    return (
        <div className='add-product-container'>
            <h3 className="signup-heading"> Update Product</h3>
            
        { error && !productName  ? <span className="error-span"> Enter product name </span>: ""}
            <input type="text" className="inputs" placeholder="Enter Product name" value={productName} onChange={(e) => setproductName(e.target.value)} />

            { error && !category  ? <span className="error-span"> Enter category name </span>: ""}
            <input type="text"  className="inputs" placeholder="Enter category name" value={category} onChange={(e) => setcategory(e.target.value)} />

            { error && !company  ? <span className="error-span"> Enter company name </span>: ""}
            <input type="text"  className="inputs" placeholder="Enter company name" value={company} onChange={(e) => setcompany(e.target.value)} />

            { error && !price  ? <span className="error-span"> Enter price </span>: ""}
            <input type="text"  className="inputs" placeholder="Enter price " value={price} onChange={(e) => setprice(e.target.value)} />

            <input type="submit" onClick={display} value="Update Product" className="btn" ></input>
        </div>
    );
}
export default UpdateProduct;