import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { car } from './user/models/carsdata';

@Injectable({
  providedIn: 'root'
})
export class MainservService {

  avail:boolean=false;
  baseurl:string="https://localhost:7011/api"
  constructor(private http:HttpClient) {
    console.log(this.avail);



   }
   getcityonly():Observable<any>{
    return this.http.get(this.baseurl+'/Cities');
   }

   getcarmodelsforfilter():Observable<any>{
    return this.http.get(this.baseurl+'/Cars/carmodels');

   }

   logdata(data:any){
    this.avail=data
    console.log(this.avail);

}
   isloggedin() :boolean{
    let x = localStorage.getItem('username')
    if(x?.length){

      return true;
    }
    return false;
   }

cit:Array<car>=[]
  getallcars():Observable<any>{
    return this.http.get(this.baseurl+'/Cars/getallcars')
  }

  register(register:any):Observable<any>{
    return this.http.post(this.baseurl+"/User1/register",register)
  }

  login(log:any):Observable<any>
{
return this.http.post(this.baseurl+"/User1/verify",log)
}


sellcar(sellit:any):Observable<any>{
  return this.http.post(this.baseurl+"/Cars/insertdata",sellit)
}



  samplecars():Observable<any>{
    return this.http.get('./assets/cars.json')
  }

  testingapi():Observable<any>{
    return this.http.get(this.baseurl+'/Testingapi/testingapi')
  }



}
