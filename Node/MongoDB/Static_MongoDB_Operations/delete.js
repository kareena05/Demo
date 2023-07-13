const dbconnection =  require('./connection');


const deleterecord = async()=>{
    const collectionName =  await dbconnection();
    // const result = await collectionName.deleteOne({name:'Tom & Jerry'});
    // if(result.modifiedCount !=0){
    //     console.log("deleted successfully");
    // }

    const result2 = await collectionName.deleteMany({name:'Tom & Jerry'});
    if(result2.modifiedCount !=0){
        console.log("deleted many successfully");
    }
}
deleterecord();