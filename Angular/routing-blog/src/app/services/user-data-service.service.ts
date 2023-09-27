import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { productModel } from 'src/models/productModel';


@Injectable({
  providedIn: 'root'
})
export class UserDataServiceService {

  constructor(private http:HttpClient) { }
  url:string="https://swapi.dev/api/people/1/"
  saveUserUrl = "http://localhost:5000/AddProduct"
  userdata(){
    var  users=[
      {name:"abhishek",industry:"IT"},
      {name:"Nisha",industry:"Engineering"},
      {name:"Sneha",industry:"Pharma"},
      {name:"Lisa",industry:"EV"}
      
    ]
    return users;    
  }
  userDataAPI(){
    var response = this.http.get(this.url);
    return response;
  }
  SaveUserAPI(data:productModel){
    var response = this.http.post(this.saveUserUrl,data);
    return response;
  }
}
