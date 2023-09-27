import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { AboutComponent } from './about/about.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { AboutMeComponent } from './about-me/about-me.component';
import { AboutCompanyComponent } from './about-company/about-company.component';
import { FooterComponent } from './footer/footer.component';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { SeniorModule } from './senior/senior.module';
import { SubAdminModule } from './sub-admin/sub-admin.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserComponent,
    AboutComponent,
    NotfoundComponent,
    AboutMeComponent,
    AboutCompanyComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    SubAdminModule,
    SeniorModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
