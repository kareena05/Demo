import { Component,EventEmitter,Input, Output } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent {
@ Input() parentData=""
@ Input() userItem:{name:string,email:string}={name:"",email:""}
@ Output() userDataEvent = new EventEmitter<string>();
}
