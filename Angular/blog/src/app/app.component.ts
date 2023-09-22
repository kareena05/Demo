import { Component } from '@angular/core';
import { NgForm,FormControl,FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'blog';
  loginForm=new FormGroup({
    username:new FormControl('Default name',[Validators.required]),
    password : new FormControl('22')
  })
 login(){
  console.log(this.loginForm.value);
 }

  audience="Techies"
  name=""
  isDisabled=false
  val="kareena"
  show=false
  color="blue"
  users = ["Peter","sam","joyson","jezz"]
  userDetails = [
    {name:"Peter",mobile:"9090",email:"peter@test.com",social:["instagram","facebook","Youtube"]},
    {name:"Sam",mobile:"9191",email:"sam@test.com",social:["Yahoo","Twitter","Snapchat"]}
  ]
  taskList:any[]=[]
  formData:any={};
  getData(val:string){
    console.log("Hello " + val);
  }
  getVal(val:string){
    console.log(val);
    this.name=val;
  }
  setDisable(){
    this.isDisabled=true
  }
  setEnable(){
    this.isDisabled=false
  }
  getFormData(data:NgForm){
    console.log("form data",data);
    this.formData=data;
  }
  getAnyFormData(data:any){
    console.log("form data",data);
    this.formData=data;
  }
  toggle(){
    this.show = !this.show;
  }
  AddTask(task:string){
    this.taskList.push({id:this.taskList.length+1,Task:task});
    console.log(this.taskList);
  }
  RemoveTask(id:number){
    this.taskList = this.taskList.filter(x=>x.id != id);
  }
}
