import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SubAdminRoutingModule } from './sub-admin-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    SubAdminRoutingModule
  ]
})
export class SubAdminModule { }
