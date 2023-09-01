import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgxPaginationModule} from 'ngx-pagination'

import { UsersRoutingModule } from './users-routing.module';
import { CityComponent } from './component/city/city.component';
import { HomepageComponent } from './component/homepage/homepage.component';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SellcarComponent } from './component/sellcar/sellcar.component';
import { AccountComponent } from './component/account/account.component';
import { PersonalinformationComponent } from './component/personalinformation/personalinformation.component';
import { SellOrdersComponent } from './component/sell-orders/sell-orders.component';
import { TestDriveComponent } from './component/test-drive/test-drive.component';
import { CarDetailsComponent } from './component/car-details/car-details.component';
import { KmconvertPipe } from '../pipes/kmconvert.pipe';
import { BookingcartComponent } from './component/bookingcart/bookingcart.component';
import { BookedcarsComponent } from './component/bookedcars/bookedcars.component';
import { FooterComponent } from './component/footer/footer.component';
import { NavbarComponent } from './component/navbar/navbar.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { WishlistComponent } from './component/wishlist/wishlist.component';
import {RxSelectModule} from '@rxweb/angular/select';


@NgModule({
  declarations: [
    NavbarComponent,
    CityComponent,
    HomepageComponent,
    FooterComponent,
    SignupComponent,
    LoginComponent,
    SellcarComponent,
    AccountComponent,
    PersonalinformationComponent,
    SellOrdersComponent,
    TestDriveComponent,
    CarDetailsComponent,
    KmconvertPipe,
    BookingcartComponent,
    BookedcarsComponent,
    ResetpasswordComponent,
    WishlistComponent
  
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPaginationModule,

    RxSelectModule
  ]
})
export class UsersModule { }
