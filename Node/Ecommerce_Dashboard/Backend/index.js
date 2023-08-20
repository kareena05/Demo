const express = require('express');
require('./db/config');
const cors = require('cors');
const Users = require('./db/schemas/Users');
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
app.listen(5000);
