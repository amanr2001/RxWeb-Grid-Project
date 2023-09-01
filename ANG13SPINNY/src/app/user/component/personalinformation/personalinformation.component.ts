import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';
import { UserstoreService } from 'src/services/userstore.service';

@Component({
  selector: 'app-personalinformation',
  templateUrl: './personalinformation.component.html',
  styleUrls: ['./personalinformation.component.css']
})
export class PersonalinformationComponent implements OnInit{


  isInputDisabled: boolean=true;
  name!:string|null;
  mail!:string|null;
  profileForm!:FormGroup;
  constructor(private demo:MainservService,private fb:FormBuilder,private http:HttpClient,private router:Router,private storeserv:UserstoreService) {
    // this.name=localStorage.getItem('username');
    this.profileForm=this.fb.group({
      username:['',Validators.required],
      useremail:[{value:'',disabled:true}]
    })
    // this.mail=localStorage.getItem('useremail');


  }

  ngOnInit(): void {
    this.storeserv.setstoredata();
    this.storeserv.userdetail.subscribe(resp=>{
      if(resp.username!=undefined){
        this.name=resp.username
        //console.log(this.name);
        this.mail=resp.useremail
        this.profileForm.patchValue({'username':this.name,'useremail':this.mail})
      }
    })

    this.profileForm.get('username')?.disable();
  }
  get uname(){
    return this.profileForm.get('username')
  }



  EditProfile(){
    this.isInputDisabled=false;
    this.profileForm.get('username')?.enable();

    //console.log(this.isInputDisabled);

  }
  Done(){
    let i  = localStorage.getItem('id');
    let pForm=this.profileForm.value
    this.demo.profileUpdate(i,pForm).subscribe(data=>{
      //console.log(data);
      if(data==null){

        this.isInputDisabled=true;
        this.profileForm.get('username')?.disable();
        localStorage.setItem('username',pForm.username)
        // this.name=localStorage.getItem('username');
        this.storeserv.setstoredata();
        //console.log(this.isInputDisabled);
      }

    })
  }
}
