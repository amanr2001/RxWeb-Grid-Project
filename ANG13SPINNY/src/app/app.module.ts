import { HttpClientModule } from '@angular/common/http';
import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {NgxPaginationModule} from 'ngx-pagination'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersModule } from './user/users.module';
import { KmconvertPipe } from './pipes/kmconvert.pipe';
import { ServerdownComponent } from './serverdown/serverdown.component';
import { LoaderComponent } from './loader/loader.component';
import { AdminModule } from './Admin/admin.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
// import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { getapi } from './Admin/stores/sellrequeststore/store.effects';
import { getreducer } from './Admin/stores/sellrequeststore/store.reducer';
import { getuserreducer } from './Admin/stores/userstore/userstore.reducer';
import { getuserapi } from './Admin/stores/userstore/userstore.effects';
import { getorderapi } from './Admin/stores/orderstore/orderstore.effect';
import { getorderreducer } from './Admin/stores/orderstore/orderstore.reducer';
import { JwtHelperService,JwtModule } from '@auth0/angular-jwt';
import { paymentreducer } from './Admin/stores/paymentstore/paymentstore.reducer';
import { paymentapi } from './Admin/stores/paymentstore/paymentstore.effects';
import { FormsModule } from '@angular/forms';
import { getcity } from './Admin/stores/Citystore/city.effect';
import { cityreducer } from './Admin/stores/Citystore/city.reducer';
import { PathnotfoundComponent } from './pathnotfound/pathnotfound.component';
import {RxSelectModule} from '@rxweb/angular/select';
import { GridModule } from '@rxweb/grid';


@NgModule({
  declarations: [
    AppComponent,
    ServerdownComponent,
    LoaderComponent,
    PathnotfoundComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsersModule,
    RxSelectModule,
    GridModule,
    NgxPaginationModule,
    
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('token'),
        allowedDomains: ['example.com'],
        disallowedRoutes: ['example.com/auth/login'],
      },
    }),
    AdminModule,
    StoreModule.forRoot({sellcars:getreducer,users:getuserreducer,orders:getorderreducer,payment:paymentreducer,city:cityreducer}, {}),
    EffectsModule.forRoot([getapi,getuserapi,getorderapi,paymentapi,getcity])
    // StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() })
  ],
  providers: [JwtHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }
