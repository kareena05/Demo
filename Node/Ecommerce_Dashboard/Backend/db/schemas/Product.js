const mongoose = require('mongoose');
const ProductSchema = new mongoose.Schema({
    productName:String,
    category:String,
    company:String,
    price:Number,
    userId:String,

});

module.exports = mongoose.model('products',ProductSchema);