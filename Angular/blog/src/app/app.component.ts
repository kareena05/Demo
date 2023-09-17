import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'blog';
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

}
