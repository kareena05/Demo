import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit ,Input} from '@angular/core';
import { UserlistService } from '../services/userlist.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private userservice:UserlistService) { }
  userlilst:{fullname:string,email:string,password:string}={fullname:"",email:"",password:""}

  signupform= new FormGroup({
    fullname:new FormControl(),
    email:new FormControl('',Validators.required),
    password:new FormControl(),

  });
Signup(data:any){
  console.log(data);
  this.userservice.AddNewUser(data);
}

  ngOnInit(): void {
  }

}
