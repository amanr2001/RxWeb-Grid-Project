import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { loaddata } from '../../stores/sellrequeststore/store.action';
import { sellcar } from '../../stores/models/sellcarmodel';
import { carapproval, carreqlength } from '../../stores/sellrequeststore/store.selector';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ord, order } from '../../stores/models/ordermodel';
import { ordersarray } from '../../stores/orderstore/orderstore.selector';
import { Router } from '@angular/router';
import { AppGrid } from '../app-grid';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{

  carlen!:Observable<number>
  constructor(private store:Store<Array<sellcar>>,private http:HttpClient,private router:Router){
    this.store.dispatch(loaddata())
    this.store.select(carapproval)
  
  }
  xyz!:Observable<number>
  ngOnInit(): void {
    this.carlen=this.store.select(carreqlength)
    this.xyz = this.store.select(ordersarray)
    this.getstatus();
    this.http.get("https://localhost:7011/api/Payment/getuserdataaa").subscribe({
      next:(res:any)=>{
        console.log(res);
        this.userdata = res
      }
    })
  }

 
  logout(){
    localStorage.clear()
    this.router.navigate(['login'])
  }
 
  get data(){
    return localStorage.getItem('username')
  }

  getstatus(){
    if(!this.data){
      alert("Session Expired")
    }
  }
  userdata:Array<any>=[]
  searchdata:Array<any>=[]
  search(keyword:any){
    // if(keyword.length!=0){
      this.searchdata=this.userdata.filter(x=>x.toLowerCase().match(keyword.toLowerCase()))
      
    // }
    console.log(keyword);
  
    
    console.log(this.searchdata);
  }
}
