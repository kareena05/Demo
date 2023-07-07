const path=require('path');
const express = require('express');
const app = express();
const { access } = require('fs');
const middleware = require('./middleware');

//path where your static html files are stored
const PublicPath = path.join(__dirname,'public');

//middleware to load all static files like html...
// app.use(express.static(PublicPath));




//To use ejs files from views folder
app.set('view engine','ejs');

// application level middleware
app.use(ageMiddleware);

//route level middleware
app.get('/',ageMiddleware,(req,res)=>{
    //thiss is also fine
    // res.render('');


    const obj=
        [
            {
            name:'kareena',
            post:'software developer'
            },
            {
                name:'Sam',
                post:'Prompt Engineer'
            }

        ]
    
    res.render('index',{obj});
})


app.get('/',(req,res)=>{
    //thiss is also fine
    // res.render('');


    const obj=
        [
            {
            name:'kareena',
            post:'software developer'
            },
            {
                name:'Sam',
                post:'Prompt Engineer'
            }

        ]
    
    res.render('index',{obj});
})

//listen website on this port
app.listen(5000);