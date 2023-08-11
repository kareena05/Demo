const mysql = require('mysql8');
const con = mysql.createConnection({
    host:'localhost',
    user:'root',
    password:"ProEx@2013",
    database:'test'
});

con.connect((err)=> err? console.log(err):console.log('connected'));
module.exports = con;
