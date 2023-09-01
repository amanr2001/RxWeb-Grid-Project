import { Component } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { user } from '../../stores/models/usermodel';
import { userbyid } from '../../stores/userstore/userstore.selector';
import { loaduser } from '../../stores/userstore/userstore.action';
import { sellcar } from '../../stores/models/sellcarmodel';
import { carbyuser } from '../../stores/sellrequeststore/store.selector';
import { order } from '../../stores/models/ordermodel';
import { orderbyuser } from '../../stores/orderstore/orderstore.selector';
import { loadorder } from '../../stores/orderstore/orderstore.action';
import { loadpayment } from '../../stores/paymentstore/paymentstore.action';
import { paymentbyuser } from '../../stores/paymentstore/paymentstore.selector';
import { pay } from '../../stores/models/paymentmodel';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent {
usdata!:Observable<Array<user>> 
cardata!:Observable<Array<sellcar>>
orderdata!:Observable<Array<order>>
paymentdata!:Observable<Array<pay>>
  constructor(private route:ActivatedRoute,private store:Store){
    this.route.params.subscribe(p=>{
      console.log(p['id']);
      this.store.dispatch(loaduser())
      this.store.dispatch(loadorder())
      this.store.dispatch(loadpayment())
      this.paymentdata=this.store.select(paymentbyuser(p['id']))

      this.usdata=this.store.select(userbyid(p['id']))  
      this.cardata=this.store.select(carbyuser(p['id']))
      this.orderdata=this.store.select(orderbyuser(p['id']))
    })
    
  }
}
