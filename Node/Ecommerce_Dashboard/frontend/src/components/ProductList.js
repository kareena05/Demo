import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const ProductList = () => {
    const localdata = localStorage.getItem("user");
    const [products, SetProducts] = useState([]);
    useEffect(() => {
        getProducts();
    }, []);

    const getProducts = async () => {
        let result = await fetch("http://localhost:5000/productList");
        result = await result.json();
        if (result.length > 0) {
            SetProducts(result);
        }

    }
    const DeleteProduct = async (id) => {
        console.log(id);
        let result = await fetch(`http://localhost:5000/deleteProduct/${id}`,{
            method:"Delete"
        });
        result = await result.json();
        if(result.status==true){
            getProducts();
        }
         alert(result.message);
    }
    console.log("Product List", products);

    return (
        <div className='signup-container'>
            <h1>Welcome to Easy Commerce  {localdata ? JSON.parse(localdata).data.fullname : ""}</h1>
            <table className='product-table'>
                <thead>
                    <tr>
                        <th>SNo.</th>
                        <th>Product Name</th>
                        <th>Company</th>
                        <th>Category</th>
                        <th>Price</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        products.map((i, index) =>
                            <tr>
                                <td>{index + 1}</td>
                                <td>{i.productName}</td>
                                <td>{i.company}</td>
                                <td>{i.category}</td>
                                <td>{i.price}</td>
                                <td><button onClick={()=>DeleteProduct(i._id)}>Delete</button>
                                <button><Link to={`/updateProduct/${i._id}`}>Update</Link></button></td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        </div>
    );
}
export default ProductList;