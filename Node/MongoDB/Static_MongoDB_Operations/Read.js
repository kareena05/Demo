const dbconnection = require('./connection');

const readcollection = async()=>{
  const collectionName = await dbconnection();
  const data =await collectionName.find().toArray();
  console.log(data);
}


readcollection();