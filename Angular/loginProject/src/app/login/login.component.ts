import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserlistService } from '../services/userlist.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private userService:UserlistService) { }
  loginform= new FormGroup({
    fullname:new FormControl(),
    email:new FormControl('',Validators.required),
    password:new FormControl(),

  });
  login(data:any){
    console.log("login called",data);
    var userlist = this.userService.GetUsers();
    if(userlist.length==0){
      return "";
    }
  }
  ngOnInit(): void {
  }

}
