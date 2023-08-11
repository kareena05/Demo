const { default: mongoose } = require('mongoose');
const nongoose = require('mongoose');
const db =  mongoose.connect('mongodb://127.0.0.1:27017/DemoDB').then(()=>console.log("connected")).catch(()=>{console.log("Not Connected")});
    const ProductSchema = new mongoose.Schema({
        name:String,
        price:Number,
        category:String
    }
    );

const SaveAsync = async()=>{
    
    const ProductModel =  mongoose.model('products',ProductSchema);
    let NewProduct = new ProductModel({name:"Vivo v11",price:57000,category:'Mobiles'});
    const result = await NewProduct.save();
    console.log(result);
    
}
const UpdateAsync = async()=>{
    
    const ProductModel =  mongoose.model('products',ProductSchema);
    let Product = await ProductModel.updateOne (
        {name:"Vivo v11"},
        {
             $set:{
                price:45000
            }
        }
        );
    
    console.log(Product);
    
}
const DeleteAsync = async()=>{
    
    const ProductModel =  mongoose.model('products',ProductSchema);
    let Product = await ProductModel.deleteOne (
        {name:"Vivo v11",price:57000}
        );
    
    console.log(Product);
    
}
const FindAsync = async()=>{
    
    const ProductModel =  mongoose.model('products',ProductSchema);
    let Product = await ProductModel.find();
   //let Product = await ProductModel.find({category:"Mobiles"});
    
    console.log(Product);
    
}
// UpdateAsync();

// DeleteAsync();
FindAsync();