import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'loginProject';
  userlilst:{fullname:string,email:string,password:string}={fullname:"",email:"",password:""}
}
