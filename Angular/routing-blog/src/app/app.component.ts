import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'routing-blog';
  memberData = [
    { name: "aman", email: "abc@gmail.com" },
    { name: "jatan", email: "jatan@gmail.com" },
    { name: "naman", email: "naman@gmail.com" },


  ]
}
