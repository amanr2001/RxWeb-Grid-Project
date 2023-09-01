import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';
import { UserstoreService } from 'src/services/userstore.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit{

  name!:string|null;
  mail!:string|null;
  constructor(private demo:MainservService,private fb:FormBuilder,private http:HttpClient,private router:Router,private storeserv:UserstoreService) {
    // this.name=localStorage.getItem('username');
    // this.mail=localStorage.getItem('useremail');
    this.storeserv.userdetail.subscribe(resp=>{
      if(resp.username!=undefined){
        this.name=resp.username
        //console.log(this.name);
        this.mail=resp.useremail
      }
    })


  }

  ngOnInit(): void {

  }


  logout(){

    localStorage.clear()
    this.router.navigate([''])
  }
}
