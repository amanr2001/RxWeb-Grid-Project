import { Injectable } from "@angular/core";
import { StoreServiceService } from "../services/store-service.service";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadorder, loadordersuccess } from "./orderstore.action";
import { map, switchMap } from "rxjs";

@Injectable()
export class getorderapi{
    constructor(private storeserv:StoreServiceService,private action:Actions){}
    loadorder$=createEffect(()=>
    this.action.pipe(
        ofType(loadorder),
        switchMap(()=>this.storeserv.getorderdata().pipe(
            map(orders=>loadordersuccess({orders}))
        ))
    )
    )
}