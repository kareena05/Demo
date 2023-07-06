const http = require('http');
const data = require('./data');
const { json } = require('stream/consumers');



http.createServer((req,res)=>{
res.writeHead(200,{'content-type':'application/json'});
res.end(JSON.stringify(data));
}).listen(8000);



console.log(process.argv[2]);