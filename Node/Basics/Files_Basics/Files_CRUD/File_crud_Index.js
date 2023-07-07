const fs = require('fs');
const path = require('path');

//path where u want to create the file
let dir = path.join(__dirname);
let filepath = dir+"/facebook.txt";
let newpath = dir+"/meta.txt";

// //create file
fs.writeFileSync(filepath,"I am the parent company of Instagram");


//read file

fs.readFile(filepath,'utf-8',(err,item)=>{
 console.log(item);
});

// append into file
fs.appendFile(filepath," and Now I am Meta !",(err)=>{
  if(!err) console.log("Content Updated!");
});

//rename the file
fs.rename(filepath,newpath,(err)=>{
    if(!err){
        console.log("File renamed!");
    }
});

//delete the file

// fs.unlinkSync(newpath);