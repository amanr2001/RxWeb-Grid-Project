import { Injectable } from '@angular/core';
import { user } from './user/models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthservService {

  auth: boolean = false
  adminauth: boolean = false
  constructor() { }
  userdata = {} as user
  verification(role: string | null) {
    if (role == '2') {
      this.auth = true;
    }
    else if (role == '1') {
      this.adminauth = true
      // console.log(role);
      // console.log(this.auth);


    }
    else {
      this.auth = false
      this.adminauth = false
    }
    this.isuserloggedin()
  }
  isuserloggedin() {
    console.log(this.auth);

    return this.auth

  }
  isadminloggedin() {
    return this.adminauth
  }

}
