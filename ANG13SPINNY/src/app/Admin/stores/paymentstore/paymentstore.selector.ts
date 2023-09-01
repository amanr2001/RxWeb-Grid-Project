import { createFeatureSelector, createSelector } from "@ngrx/store";
import { pay } from "../models/paymentmodel";

export const selectpayment = createFeatureSelector<Array<pay>>('payment')
export const paymentbyuser =(id:number)=>createSelector(selectpayment,(payment)=>{
    return payment.filter(x=>x.createdBy==id)
})

export const paylen = createSelector(selectpayment,(payment)=>{
    return payment.length
})

export const last5Dpayments= createSelector(selectpayment,(payment)=>{
    var a = 0; 
    for (var i = 0; i <5 ; i++) {
      let x = payment[i]?.paymentamount ;
      a += x; 
    }
 
    
    console.log(a);
    return a;
})
export const totalpayment= createSelector(selectpayment,(payment)=>{
    var ans = 0; 
    for (var i = 0; i < payment.length ; i++) {
      let x = payment[i].paymentamount ;
      ans += x; 
    }
 
    
    console.log(ans);
    return ans;
})