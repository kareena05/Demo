import { Injectable } from '@angular/core';
interface userobj{fullname:string,email:string,password:string}

@Injectable({
  providedIn: 'root'
})

export class UserlistService {

  constructor() { }
  
  userlist:userobj[]=[]
  //function to add user
  AddNewUser(data:any){
   const newUser :userobj={
    fullname:data.fullname,
    email:data.email,
    password:data.password
    
   }
   
    alert("Added New User");
   this.userlist.push(newUser);
    
    console.log(this.userlist);
  }
  //function to get the user list
  GetUsers(){
    console.log("user list:",this.userlist);
    return this.userlist;
   }
}
