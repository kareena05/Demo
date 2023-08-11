const express = require('express');
const app = express();
app.use(express.json());

app.get('/',(req,res)=>{
    res.send("Welcome Easy Commerce!")
});

app.listen(5000);