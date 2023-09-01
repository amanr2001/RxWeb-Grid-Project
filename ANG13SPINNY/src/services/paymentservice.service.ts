import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PaymentserviceService {

  constructor(private http:HttpClient) { }
  public baseurl = environment.apiUrl;

  createOrder(amount:number){
    const data={
      amount:amount,
      currency:'INR',
      receipt:'Order123'
    }
    return this.http.post(this.baseurl+'/Payment/api/payments/create-order',data)


  }
}
