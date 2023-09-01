import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { upddata } from '../models/sellcarmodel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StoreServiceService {

  constructor(private http:HttpClient) { }
  public baseurl = environment.apiUrl;

  getsellreq():Observable<any>{
    return this.http.get(this.baseurl+'/Admin')
  }

  updatecardata(id:number,sellcars:upddata):Observable<any>{
    return this.http.put(this.baseurl+'/Admin/'+id,sellcars)
  }

  delcarreq(id:number):Observable<any>{
    return this.http.delete(this.baseurl+'/Admin/'+id)
  }

  getuserdata():Observable<any>{
    return this.http.get(this.baseurl+'/Admin/getusers')
  }
  getorderdata():Observable<any>{
    return this.http.get(this.baseurl+'/Admin/orderdata')
  }

  getpaymentdetails():Observable<any>{
    return this.http.get(this.baseurl+'/Payment/paymentportal')
  }
  denyreq(i:number):Observable<any>{
    return this.http.put<any>(this.baseurl+"/Admin/Denyreq/"+i,"s");
  }

  getcity():Observable<any>{
    return this.http.get<any>(this.baseurl+'/Admin/GetCities');
  }
  addoutlets(city:any):Observable<any>{
    return this.http.post<any>(this.baseurl+"/Admin/Addoutlets",city)
  }

  addcity(city:string){
    return this.http.post<any>(this.baseurl+"/Admin/addcitites",city)
  }

  getmainpageTabData(){
    return this.http.get(this.baseurl+"/MainPages/AdminPanelTab")
  }

  updatemainpage(id:number,data:any){
    return this.http.put(this.baseurl+"/MainPages/"+id,data)
  }

  deletemainpagedata(id:number){
    return this.http.delete(this.baseurl+"/MainPages/"+id)
  }
}
