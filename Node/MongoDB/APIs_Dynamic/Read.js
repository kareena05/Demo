const dbconnection = require('../connection');
const express = require('express');
const app = express();


app.get('/',async (req,res)=>{
   const db = await dbconnection();
   const result = await db.find().toArray();
   res.send(result);
})

app.listen(5000);