import { Injectable } from '@angular/core';
import { user } from '../app/user/models/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import jwt_decode, { JwtPayload } from "jwt-decode";
import { LoaderService } from './loader.service';
import { Router } from '@angular/router';
import { MainservService } from './mainserv.service';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthservService {

  auth: boolean = false
  adminauth: boolean = false
  isverified:boolean=false
  constructor(private http: HttpClient, private loader: LoaderService, private router: Router, private demo: MainservService,) { }
  public baseurl = environment.apiUrl;



  register(register: any): Observable<any> {
    return this.http.post(this.baseurl + "/User1/register", register)
  }
  userarr: any;
  available: boolean = false
  role!: any


  login(log: any) {
    this.http.post<any>(this.baseurl + "/User1/verify", log).subscribe({
      next: (x: any) => {
        if (x != null) {

          this.userarr = x.token
          localStorage.setItem('token', x.token);
          const payload: any = jwt_decode(x.token);
          console.log(payload);

          console.log(payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"]);

          this.available = true;
          localStorage.setItem('username', payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"])
          localStorage.setItem('useremail', payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"])
          localStorage.setItem('id', payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"])
          localStorage.setItem('role', payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
          let name = localStorage.getItem('username')
          let email = localStorage.getItem('useremail')
          this.role = localStorage.getItem('role')
          if (this.role == '1') {
            this.router.navigate(['admin'])
          } else {

            this.router.navigate([''])
          }
          this.loader.setFlag(false)
        }
        else {
          this.loader.setFlag(false)
          this.available = false
        }
        // console.log(x.token);


        this.demo.logdata(this.available)


      },
      error: (err: any) => {
        alert("Incorrect Data")
        this.loader.setFlag(false)

      }
    }
    )
  }
  

  islogin(){
    let token = localStorage.getItem('token');
    if(token){
      return true
    }
    else {
      
      return false;
    }
  }
  get rolee(){
    return localStorage.getItem('role')

  }
  
  isuser() {

    console.log(this.rolee);

    if (this.rolee == '2' && this.islogin() ) {

      return true
    }
    else {
      

      return false
    }
  }

  isadmin() {
    if (this.rolee == '1' && this.islogin()) {
      return true
    }
    else {
      
      return false
    }
  }

}


