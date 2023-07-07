// custom middleware
module.exports=ageMiddleware =  (req,res,next)=>{
    if(!req.query.age){
        res.send("<h1>Please provide Age!");
    }else if(req.query.age<18){
        res.send('<h1>Sorry You can not access our website</h1>');
    }else{
        next();
    }
}
