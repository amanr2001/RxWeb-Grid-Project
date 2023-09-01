import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServerdownComponent } from '../serverdown/serverdown.component';
import { AccountComponent } from './component/account/account.component';
import { BookingcartComponent } from './component/bookingcart/bookingcart.component';
import { CarDetailsComponent } from './component/car-details/car-details.component';
import { CityComponent } from './component/city/city.component';
import { HomepageComponent } from './component/homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { PersonalinformationComponent } from './component/personalinformation/personalinformation.component';
import { SellOrdersComponent } from './component/sell-orders/sell-orders.component';
import { SellcarComponent } from './component/sellcar/sellcar.component';
import { SignupComponent } from './signup/signup.component';
import { TestDriveComponent } from './component/test-drive/test-drive.component';
import { BookedcarsComponent } from './component/bookedcars/bookedcars.component';
import { NavbarComponent } from './component/navbar/navbar.component';
import { AuthenticationGuard } from '../authentication.guard';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { VerifiedGuardGuard } from '../verified-guard.guard';
import { WishlistComponent } from './component/wishlist/wishlist.component';
import { PathnotfoundComponent } from '../pathnotfound/pathnotfound.component';

const routes: Routes = 
[

  {path:'',component:NavbarComponent
  ,  children:[
  {path:"",component:HomepageComponent},
  {path:'used/:cityname',component:CityComponent},
  {path:'used/:cityname/:carb',component:CityComponent,canActivate:[AuthenticationGuard]},
  {path:'app',component:CityComponent,canActivate:[AuthenticationGuard]},
  {path:'signup',component:SignupComponent},
  {path:'resetpass/:id',component:ResetpasswordComponent,canActivate:[VerifiedGuardGuard]},
  {path:'login',component:LoginComponent},
  {path:'sell',component:SellcarComponent,canActivate:[AuthenticationGuard]},
  {path:'cars/:id',component:CarDetailsComponent,canActivate:[AuthenticationGuard]},
  {path:'cart',component:BookingcartComponent},
  {path:'wishlist',component:WishlistComponent,canActivate:[AuthenticationGuard]},
  {path:'account',component:AccountComponent,canActivate:[AuthenticationGuard],
  children:[
    {path:'',component:PersonalinformationComponent},
    {path:'sell-orders',component:SellOrdersComponent},
    {path:'testD',component:TestDriveComponent},
    {path:'bookedcar',component:BookedcarsComponent}
  ]
  },
  
],
},
{path:'serverdown',component:ServerdownComponent},
];
// [

 
//   {path:'',component:NavbarComponent
// ,  children:[
//   {path:"",component:HomepageComponent},
//   {path:'used/:cityname',component:CityComponent},
//   {path:'used/:cityname/:carb',component:CityComponent},
//   {path:'app',component:CityComponent},
//   {path:'signup',component:SignupComponent},
//   {path:'login',component:LoginComponent},
//   {path:'sell',component:SellcarComponent},
//   {path:'cars/:id',component:CarDetailsComponent},
//   {path:'cart',component:BookingcartComponent},
//   {path:'account',component:AccountComponent,
//   children:[
//     {path:'',component:PersonalinformationComponent},
//     {path:'sell-orders',component:SellOrdersComponent},
//     {path:'testD',component:TestDriveComponent},
//     {path:'bookedcar',component:BookedcarsComponent}
//   ]
//   },
  
// ],
// },
// {path:'serverdown',component:ServerdownComponent}
// ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
