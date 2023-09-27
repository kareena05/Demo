import { UserDataServiceService } from './services/user-data-service.service';
import { Component, ComponentFactoryResolver, ViewContainerRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'routing-blog';
  AddNewProduct(data:any){
    var response = this.userdata.SaveUserAPI(data).subscribe((data)=>{
      console.log("save user response",data);
    });
   
  }
  users:any=[];
  constructor(private userdata:UserDataServiceService,private compFactory:ComponentFactoryResolver,private viewContianer:ViewContainerRef){
      //console.log(userdata.userdata());
      this.users = userdata.userdata();
    userdata.userDataAPI().subscribe((data)=>{
      console.log("the api data",data);
    });
  }
  memberData = [
    { name: "aman", email: "abc@gmail.com" },
    { name: "jatan", email: "jatan@gmail.com" },
    { name: "naman", email: "naman@gmail.com" },
  ]
}
