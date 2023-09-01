import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaymentserviceService {

  constructor(private http:HttpClient) { }

  createOrder(amount:number){
    const data={
      amount:amount,
      currency:'INR',
      receipt:'Order123'
    }
    return this.http.post('https://localhost:7011/api/Payment/api/payments/create-order',data)


  }
}
