import { Injectable } from "@angular/core";
import { StoreServiceService } from "../services/store-service.service";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadpayment, loadpaymentsuccess } from "./paymentstore.action";
import { map, switchMap } from "rxjs";

@Injectable()
export class paymentapi{
    constructor(private storeserv:StoreServiceService,private action:Actions){}
    loadpaymentapi$=createEffect(()=>
    this.action.pipe(
        ofType(loadpayment),
        switchMap(()=>this.storeserv.getpaymentdetails().pipe(
            map(payment=>loadpaymentsuccess({payment}))
        ))
    ))
}