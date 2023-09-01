import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './Component/navbar/navbar.component';
import { MainpageComponent } from './Component/mainpage/mainpage.component';
import { SellapprovalComponent } from './Component/sellapproval/sellapproval.component';
import { UserdetailsComponent } from './Component/userdetails/userdetails.component';
import { AuthGuard } from '../auth.guard';
import { OutletsComponent } from './Component/outlets/outlets.component';
import { AdminauthGuard } from '../adminauth.guard';
import { PathnotfoundComponent } from '../pathnotfound/pathnotfound.component';
import { UserHomePageComponent } from './Component/user-home-page/user-home-page.component';

const routes: Routes = [
  {path:'admin',component:NavbarComponent,canActivate:[AuthGuard],
  children:[
    {path:'',component:MainpageComponent},
    {path:'carapproval',component:SellapprovalComponent,canActivate:[AuthGuard]},
    {path:'userdet/:id',component:UserdetailsComponent,canActivate:[AuthGuard]},
    {path:'addoutlet',component:OutletsComponent,canActivate:[AuthGuard]},
    {path:'managepage',component:UserHomePageComponent}
  ]
},
// { path: '**', component: PathnotfoundComponent }   

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
