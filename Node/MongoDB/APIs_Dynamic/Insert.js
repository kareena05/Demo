const dbconnection = require('../connection');
const express = require('express');
const app = express();
app.post('/',async()=>{
  const db = await dbconnection();
  const result = await db.insertOne({
    name: "Motu & Patlu",
    releasing_year: "2011",
    ratings: "4.5"
})
  // const result2 = await collectionName.insertMany([
  //   { name: "Tom & Jerry", releasing_year: "2012", ratings: "4.0" },
  //   { name: "Tom & Jerry", releasing_year: "2012", ratings: "4.0" },
  //   { name: "Tom & Jerry", releasing_year: "2012", ratings: "4.0" },
  // ]);
  //use array to insert many [{name:'Tom & Jerry',ratings:"4.0"},{name:'Tom & Jerry',ratings:"4.0"}]
  if (result.acknowledged) {
    console.log("Inserted Successfully");
  }
});

app.listen(5000);


