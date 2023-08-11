const dbconnection = require('../connection');
const express = require('express');
const app = express();
const mongodb = require('mongodb');


app.use(express.json());
app.get('/',async (req,res)=>{
   res.send(req.body);
})

app.post('/insert',async(req,res)=>{
   let db = await dbconnection();
   let result = await db.insertOne(req.body);
   res.send("Inserted!")
})

app.post('/insert',async(req,res)=>{
    let db = await dbconnection();
    let result = await db.insertOne(req.body);
    if(result.modifiedCount >0){
     console.log("Inserted");
     res.send("inserted...")
    }res.send("Not inserted!")
 })

 app.put('/update',async(req,res)=>{
    let db = await dbconnection();
    let result = await db.updateOne({name:req.params.cartoonName},{$set:{"releasing_year":"2013"}});
    res.send("Updated")
 })

 app.delete('/delete/:id',async(req,res)=>{
   console.log(req.params.id);
   const db = await dbconnection();
   const result = await db.deleteOne({_id: new mongodb.ObjectId(req.params.id)});

   res.send(result);
 })

app.listen(5000);