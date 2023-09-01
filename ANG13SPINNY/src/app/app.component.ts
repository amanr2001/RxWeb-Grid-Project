import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoaderService } from '../services/loader.service';
import { MainservService } from '../services/mainserv.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthservService } from 'src/services/authserv.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'spinny';

constructor(private demo:MainservService,private router :Router, private loaderServ:LoaderService,private jwthelper:JwtHelperService,private authserv:AuthservService) {

}

get flag(){
  return this.loaderServ.flag
}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.authserv.islogin();
    this.demo.testingapi().subscribe(
      {
        next:(response:any)=>{

        },
        error:(err:any)=>{
          this.router.navigate(['serverdown'])
          this.loaderServ.setFlag(false)
        }

      }
    )

    const token:any = localStorage.getItem('token')
    if(this.jwthelper.isTokenExpired(token)==true){
      localStorage.clear()
    }
  }


}
