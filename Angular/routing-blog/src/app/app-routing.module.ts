import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UserComponent } from './user/user.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { AboutMeComponent } from './about-me/about-me.component';
import { AboutCompanyComponent } from './about-company/about-company.component';

const routes: Routes = [
  {
path:"lazy",
loadChildren:()=>import('./lazy-load/lazy-load.module').then((module)=>
module.LazyLoadModule)
  },
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'about',
    component:AboutComponent,
    children:[
      {path:'me',component:AboutMeComponent},
      {path:'company',component:AboutCompanyComponent},

    ]
  },
  {
    path:'user/:id',
    component:UserComponent
  },{
    path:'**',
    component:NotfoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
