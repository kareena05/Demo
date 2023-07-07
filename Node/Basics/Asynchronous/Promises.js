let a=10;
let b =0;

let waitingData = new Promise((resolve,reject)=>{
   setTimeout(()=>{
    b=30;
    resolve();
   },2000);
});

//this will be executed later (after 2 seconds)
waitingData.then(()=>{
    console.log(a+b);
});

//this will be executed first
console.log(a+b);