const dbconnection = require("./connection");

const insertion = async () => {
  const collectionName = await dbconnection();
  const result = await collectionName.insertOne({
    name: "Tom & Jerry",
    releasing_year: "2012",
    ratings: "4.0",
  });

  const result2 = await collectionName.insertMany([
    { name: "Tom & Jerry", releasing_year: "2012", ratings: "4.0" },
    { name: "Tom & Jerry", releasing_year: "2012", ratings: "4.0" },
    { name: "Tom & Jerry", releasing_year: "2012", ratings: "4.0" },
  ]);
  //use array to insert many [{name:'Tom & Jerry',ratings:"4.0"},{name:'Tom & Jerry',ratings:"4.0"}]
  if (result.acknowledged) {
    console.log("Inserted Successfully");
  }
};

insertion();
