import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreServiceService } from '../../stores/services/store-service.service';
import { Store } from '@ngrx/store';
import { createoutlets } from '../../stores/Citystore/city.action';

@Component({
  selector: 'app-outlets',
  templateUrl: './outlets.component.html',
  styleUrls: ['./outlets.component.css']
})
export class OutletsComponent {

  addoutletForm!:FormGroup;
  addcity!:FormGroup;
  citydata!:any
  constructor(private fb:FormBuilder,private route:ActivatedRoute,private Router:Router,private serv : StoreServiceService,private store:Store){
    this.addoutletForm = this.fb.group({
      outletlocation:['',Validators.required],
      cityid:['',Validators.required]
    })

    this.addcity = this.fb.group({
      cityname:['',Validators.required]
    })


    this.serv.getcity().subscribe({
      next:(res:any)=>{
        this.citydata = res
      },error:(err:any)=>{
        
      }
    })
    
    

  }
  get outloc(){
    return this.addoutletForm.get('outletlocation')
  }
  get cit(){
    return this.addoutletForm.get('cityid')
  }
  get cityname(){
    return this.addcity.get('cityname')
  }

  Addouts(){
      let city = this.addoutletForm.value;
      console.log(city);
      
      this.store.dispatch(createoutlets({city:city}))
      alert("Outlet Added")
      this.addoutletForm.reset();
  }

  Addcit(){
    let cit = this.addcity.value;
    this.serv.addcity(cit).subscribe({
      next:(res:any)=>{
        alert("City Added")
        this.addcity.reset();
      },
      error:(err:any)=>{


      }
    })
  }
}
