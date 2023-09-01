import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.css']
})
export class ResetpasswordComponent {
id!:number;
passwordreset!:FormGroup;

  constructor(private demo:MainservService,private route:ActivatedRoute,private fb:FormBuilder,private router:Router) { 

    this.route.params.subscribe(x=>{
this.id = x['id']
    })
    this.passwordreset=this.fb.group({
      password:['',Validators.required],
    })
  }



  get rpass(){
    return this.passwordreset.get('password');
  }

  reset(){
    let resetpass = this.passwordreset.value;
    this.demo.resetpass(resetpass,this.id).subscribe({
      next:(res:any)=>{
        alert("successfully updated password")
        this.router.navigate(['login'])
      },
      error:(err:any)=>{
        alert("error while changing password")
      }
    })
  }
}

