
const express = require('express');
const app = express();

app.use(express.json());
app.get('/',async (req,res)=>{
   res.send(req.body);
})

app.listen(5000);