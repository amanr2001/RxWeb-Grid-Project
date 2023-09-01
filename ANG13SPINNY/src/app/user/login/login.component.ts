import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';
import  jwt_decode, { JwtPayload } from "jwt-decode";
import { LoaderService } from 'src/services/loader.service';
import { AuthservService } from 'src/services/authserv.service';
import { user } from '../models/user';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
loginform!:FormGroup;
emailforgot!:FormGroup;
forgototp!:FormGroup;
available:boolean=false
flag:boolean=false
  constructor(private demo:MainservService, private fb:FormBuilder,private router:Router, private loader:LoaderService,private authserv:AuthservService) {
      this.loginform=this.fb.group({
        username:['',Validators.required],
        password:['',Validators.required]
      })

      this.emailforgot = this.fb.group({
        email: ['', [Validators.required,Validators.email]]
      })

      this.forgototp = this.fb.group({
        otp:['',Validators.required]
      })

  }

  get uname(){
    return this.loginform.get('username')
  }
  get pass(){
    return this.loginform.get('password')
  }
  get uemail(){
    return this.emailforgot.get("email")
  }
  get uotp(){
    return this.forgototp.get('otp')
  }

userarr:any;


logged(){
  let logindata:user = this.loginform.value;
  this.loader.setFlag(true)
  this.authserv.login(logindata)

  // .subscribe(x=>{
  //   if(x!=null){

  //     this.userarr=x.token
  //     localStorage.setItem('token',x.token);
  //     const payload:any=jwt_decode(x.token);
  //     //console.log(payload);

  //     //console.log(payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"]);

  //     this.available=true;
  //     localStorage.setItem('username',payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"])
  //     localStorage.setItem('useremail',payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"])
  //     localStorage.setItem('id',payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"])
  //     localStorage.setItem('role',payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
  //     let name = localStorage.getItem('username')
  //     let email = localStorage.getItem('useremail')
  //     let role = localStorage.getItem('role')

  //     this.authserv.verification(role)
  //     this.loader.setFlag(false)
  //     this.router.navigate([''])
  //   }
  //   else{
  //     this.loader.setFlag(false)
  //     this.available=false
  //   }
  //   //console.log(x.token);


  //   this.demo.logdata(this.available)


  // })

}

forgotpass(){
  this.flag=true
}
forgotuserid!:number
sendforgototp(){
  let data = this.emailforgot.value
  this.loader.setFlag(true)

  this.demo.forgotpasswordotp(data).subscribe({
    next:(res :any)=>{
      alert("Otp Send Successfully")
      //console.log(res);
      this.forgotuserid=res
      this.loader.setFlag(false)


    },
    error:(err:any)=>{
      this.loader.setFlag(false)

      //console.log(err);

    }
  })
}
verifyotp(){

  let otp = this.forgototp.value;
  this.loader.setFlag(true)
  this.demo.verifyotp(otp,this.forgotuserid).subscribe({
    next:(res:any)=>{
      this.authserv.isverified=true
      this.loader.setFlag(false)
      this.router.navigate(['resetpass',res])
      
    }
  })
}

reset(){
  // let resetpassword = this.passwordreset.value;
  // this.demo.resetpass(resetpassword,)
}

}
