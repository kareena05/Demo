const express = require('express');
require('./db/config');
const cors = require('cors');
const Users = require('./db/schemas/Users');
const Product = require('./db/schemas/Product');
const app = express();

// Middlewares
app.use(express.json());
app.use(cors());

app.post("/signup", async (req, res) => {
    let user = new Users(req.body);
    let result = await user.save();
    result = result.toObject();
    delete result.password;
    res.send(result);
});



app.post("/login",async(req,res)=>{
    
if(req.body.password && req.body.email){
    let user = await Users.findOne(req.body).select("-password");
    if(user){
        res.send({success:true,message:"User found",data:user});
    }else{
        res.send({success:false,message:"User not found",data:[]});
    }
}else{
    res.send("Please provide email and password")
}

    
});

app.post("/AddProduct",async(req,res)=>{
   
    let product = new Product(req.body);
    let result = await product.save();
    res.send({status:true,message:"product added successfully !",data:result});
});


app.get("/productList",async(req,res)=>{
    let result = await Product.find();
    if(result.length > 0){
        res.send(result);
    }else{
        res.send({result:"No products found"});
    }
});
app.delete("/deleteProduct/:id",async(req,res)=>{
    const result = await Product.deleteOne({_id:req.params.id});
    if(result.deletedCount >0){
        res.send({status:true,message:"Product Deleted successfully"});
    }else{
        res.send({status:false, message:"Unable to Delete the product"});
    }
});

app.get("/getProduct/:id",async(req,res)=>{
    let result = await Product.findOne({_id:req.params.id});
    if(result){
        res.send(result);
    }else{
        res.send({result:"No results found"});
    }
});

app.put("/updateProduct/:id",async(req,res)=>{
    let result = await Product.updateOne(
        {_id:req.params.id},
        {
            $set:req.body
        }
    )
    if(result.modifiedCount>0){
        res.send({status:true,message:"Product Updated Successfully",data:result});
    }else{
        res.send({status:false,message:"Unable to Updated Product",data:result});
    }
    
});

app.listen(5000);
