const http = require('http');
const data = require('./data');
const { json } = require('stream/consumers');



http.createServer((req,res)=>{
res.writeHead(200,{'content-type':'application/json'});
res.end(JSON.stringify(data));
}).listen(8000);




//command line input
//by default returns two arguments son if you add your custom input it will be stored i  argv[2] and so on
console.log(process.argv[2]);