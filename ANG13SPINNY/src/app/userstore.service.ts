import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { userdata } from './user/models/sellorder';

@Injectable({
  providedIn: 'root'
})
export class UserstoreService {
   userStore:BehaviorSubject<userdata>
  constructor(private http:HttpClient) {

    const userdata = {} as userdata;
    this.userStore=new BehaviorSubject(userdata)
    this.setstoredata();

   }
   setstoredata():void{
    let i = localStorage.getItem('id')
      this.http.get<any>("https://localhost:7011/api/User1/getuserdata/"+i).subscribe(data=>{
        console.log(data);
        this.userStore.next(data);
      })
   }

   get userdetail(){
    return this.userStore.asObservable();
   }

}
