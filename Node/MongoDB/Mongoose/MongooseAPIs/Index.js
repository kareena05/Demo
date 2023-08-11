
const express = require('express');
const multer = require('multer');
require('./config');
const productModel= require('./models/products');


const app = express();

app.use(express.json());

const storage = multer.diskStorage({
    destination:function(req,file,cb){
        cb(null,'./uploads');
    },
    filename:function(req,file,cb){
        cb(null,`${Date.now()}_${file.originalname}.jpg`);
    }
});

const Upload =  multer({
    storage:storage
}).single('myfile')

app.post('/',async(req,res)=>{
    const newProduct = new productModel(req.body);
    const result = await newProduct.save();
    res.send(result);
})

app.delete('/delete/:_id',async(req,res)=>{
   
    const result = await productModel.deleteOne(req.params);
    res.send(result);
})

app.put('/update/:_id',async(req,res)=>{   
    const result = await productModel.updateOne(
        req.params,
        {
            $set:
                req.body
            
        }

        );
    res.send(result);
})


app.post('/search/:key',async(req,res)=>{   
    const result = await productModel.find(
       
    {
        "$or":[
            {"name":{$regex:req.params.key}},
            {'category':{$regex:req.params.key}}
        ]
    }

        );
    res.send(result);
});


app.post('/uploadfile',Upload,(req,res)=>{
res.send("File Uploaded");
})
app.listen(5000);