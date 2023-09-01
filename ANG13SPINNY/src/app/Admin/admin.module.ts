import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgxPaginationModule} from 'ngx-pagination'
import { AdminRoutingModule } from './admin-routing.module';
import { NavbarComponent } from './Component/navbar/navbar.component';
import { MainpageComponent } from './Component/mainpage/mainpage.component';
import { SellapprovalComponent } from './Component/sellapproval/sellapproval.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserdetailsComponent } from './Component/userdetails/userdetails.component';
import { OutletsComponent } from './Component/outlets/outlets.component';
import { UserHomePageComponent } from './Component/user-home-page/user-home-page.component';
import { GridModule } from '@rxweb/grid';

@NgModule({
  declarations: [
    NavbarComponent,
    MainpageComponent,
    SellapprovalComponent,
    UserdetailsComponent,
    OutletsComponent,
    UserHomePageComponent
  ],
  imports: [
    CommonModule,
    NgxPaginationModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    GridModule,
  ]
})
export class AdminModule { }
