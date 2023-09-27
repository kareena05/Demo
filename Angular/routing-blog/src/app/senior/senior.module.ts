import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SeniorRoutingModule } from './senior-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    SeniorRoutingModule
  ]
})
export class SeniorModule { }
