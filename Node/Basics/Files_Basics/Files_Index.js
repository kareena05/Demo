const fs = require('fs');
const path = require('path');

const mainDir= path.join(__dirname,"files");
console.log("Directory location where new files will be created:\n "+mainDir);

for(let i=0;i<4;i++){
    
    fs.writeFileSync(`${mainDir}/file${i+1}`,`I am the content of file number ${i+1}`);
}
console.log("Created files...")
fs.readdir(mainDir,(err,files)=>{
    console.log(files); //or files.ForEach(x=>console.log(x))
});

for(let i=0;i<4;i++){
    
    fs.unlinkSync(`${mainDir}/file${i+1}`);
}
console.log("After Removing files...");
fs.readdir(mainDir,(err,files)=>{
    console.log(files)
});
