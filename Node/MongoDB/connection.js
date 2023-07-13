const {MongoClient} =  require('mongodb');
const database = 'DemoDB';
const url = 'mongodb://127.0.0.1:27017';
const client = new MongoClient(url);


async function dbconnection(){
    let result = await client.connect();
    db = result.db(database);
    return db.collection('Cartoons');
}

module.exports = dbconnection;