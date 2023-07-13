const dbconnection =  require('./connection');


const update = async()=>{
    const collectionName =  await dbconnection();
    const result = await collectionName.updateMany({name:'Nohara'},{$set:{name:'Himamari'}});
    if(result.modifiedCount !=0){
        console.log("Updated successfully");
    }
}
update();