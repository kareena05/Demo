const express = require('express');
const app = express();
const con = require('./config');

app.use(express.json());

app.get('/',(req,res)=>{
    con.query("select * from users",(err,result)=>{
        if(err){
            res.send(err);
        }else{
            res.send(result);
        }
    })
    
});

app.post('/insert',(req,res)=>{
    const data = req.body;
    con.query("INSERT INTO users SET ?", data, (err,result,field)=>{
        err? res.send(err):res.send(result);
    })
});

app.put('/update/:id',(req,res)=>{
    const data = [req.body.name, req.body.city ,req.params.id];
    con.query("UPDATE users SET name=? , city =?  WHERE id=?", data, (err,result,field)=>{
        err? res.send(err):res.send(result);
    })
});


app.delete('/delete/:id',(req,res)=>{
    const data = req.params.id;
    con.query("DELETE FROM users WHERE id=?", data, (err,result,field)=>{
        err? res.send(err):res.send(result);
    })
});


app.listen(5000);
