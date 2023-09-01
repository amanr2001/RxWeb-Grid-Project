import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { car } from '../app/user/models/carsdata';
import { environment } from 'src/environments/environment';
// import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MainservService {

  avail:boolean=false;
  public baseurl = environment.apiUrl;
  // baseurl:string="https://localhost:7011/api"
  constructor(private http:HttpClient) {
    console.log(this.avail);



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
  
  // city array
  getcityonly():Observable<any>{
   return this.http.get(this.baseurl+'/Cities');
  }

  // car models
  getcarmodelsforfilter():Observable<any>{
   return this.http.get(this.baseurl+'/Cars/carmodels');

  }
// get all cars
  getallcars(){
    return this.http.get(this.baseurl+'/Cars/getallcars/')
  }

  // Get all Objects;
  getobject(){
    return this.http.get(this.baseurl+"/Obj")
  }

// SellcAr Api
sellcar(sellit:any):Observable<any>{
  return this.http.post(this.baseurl+"/Cars/insertdata",sellit)
}


// Static Car Options
  samplecars():Observable<any>{
    return this.http.get('./assets/cars.json')
  }
// Serverdown Api
  testingapi():Observable<any>{
    return this.http.get(this.baseurl+'/Testingapi/testingapi')
  }

// booking
bookcar(bookdata:any){
  return this.http.post<any>(this.baseurl+'/Orders/ordercar',bookdata)
}

// payment 
payment(obj1:any){
  return this.http.post(this.baseurl+'/Payment/paymentdata',obj1)
}


// upd payment table
paymenttable(i:string|null,data:any){
  return this.http.put(this.baseurl+'/Payment/updcarstatus/' + i, data)
}

// interested testdrive
interestedtestdrive(intTd :any){
return this.http.post<any>(this.baseurl+'/TestDrive/interestedTestdrive', intTd)
}
// get td timings
GetTestTime(date:any,Carid:number){
  return this.http.get<any>(this.baseurl+"/TestDrive/GETIME/" + date+'/'+Carid)
}


// Confirmetestdrive
confirmTestDrive(testid:string|null,val:any){
  return this.http.put<any>(this.baseurl+"/TestDrive/ConfirmedTd/" + testid, val)
}

// profile update
profileUpdate(i:string|null,pForm:any){
  return this.http.put<any>(this.baseurl+"/User1/editprofile/"+i,pForm)
}
// carsell request
CarSellReq(i:string|null){
  return this.http.get<any>(this.baseurl+`/Cars/sellrequests/+${i}`)

}
// delete sell requests
DelSellReq(i:number){
return this.http.delete(this.baseurl+`/Cars/deleteRequest/${i}`)
}


// otpauthorization
OtpAuth(otpf:any){
  return this.http.post<any>(this.baseurl+'/User1/Otp',otpf)
}

// registration
UserRegis(i:string|null,formdata:any){
return this.http.put(this.baseurl+`/User1/register/${i}`,formdata)
}

// GEt interested Testdrives

GetInterestedTestD(i:string|null){
  return this.http.get<any>(this.baseurl+'/TestDrive/getinterestedTD/'+i)
}

// Get Confirmed TestDrives

GetConfirmedTestD(i:string|null){
return this.http.get<any>(this.baseurl+"/TestDrive/GetcompletedTD/"+i)
}


forgotpasswordotp(data:any){
  return this.http.put<any>(this.baseurl+"/User1/ForgotPassword",data)
}

verifyotp(otp:any,i:number){
  return this.http.post<any>(this.baseurl+"/User1/forgotpassotpverification/"+i,otp)

}

resetpass(resetpass:any,i:number){
  return this.http.put<any>(this.baseurl+"/User1/changedpassword/"+i,resetpass)

}

// wishlist post api
wishL(data:any){
  return this.http.post<any>(this.baseurl+"/Wishlists/wishlist",data)
}

// getwishlist
getwishL(i:string|null){
  return this.http.get<any>(this.baseurl+"/Wishlists/UserWishlist/"+i)
}
// getmainpagedata
getmainpage(){
  return this.http.get<any>(this.baseurl+"/MainPages")
}


}
