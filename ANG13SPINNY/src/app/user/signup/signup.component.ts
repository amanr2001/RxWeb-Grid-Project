import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent {
  form!: FormGroup;
  otpform!:FormGroup;
  constructor(private demo: MainservService, private fb: FormBuilder,private http:HttpClient,private router:Router) {
    this.form = this.fb.group({
      Username: ['', [Validators.required]],
      Password: ['', [Validators.required,Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')]],
      otp:['',Validators.required]
    });

    this.otpform=this.fb.group({
      useremail: ['', [Validators.required,Validators.email]]

    })

  }


  get uname(){
    return this.form.get('Username')
  }
  get upass(){
    return this.form.get('Password')
  }
  get umail(){
    return this.otpform.get('useremail')
  }

  otpauth() {
    let otpf=this.otpform.value
    let formdata = this.form.value;

    this.demo.OtpAuth(otpf).subscribe({
      next:(data:any)=>{
        localStorage.setItem('id',data.id)
      },
      error:((err:any)=>{
        console.log(err.error);
        
      })
    })
    
  }


  regis() {
    let formdata = this.form.value;

    var i = localStorage.getItem('id')
    console.log(i);

    this.demo.UserRegis(i,formdata).subscribe({
      next:(data:any)=>{
        console.log(data);
        this.router.navigate(['login'])
      },
      error:(err:any)=>{
        alert(err.error);

        
      }
    })
    console.log(formdata);

  }
}
