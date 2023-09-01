import { Injectable } from "@angular/core";
import { StoreServiceService } from "../services/store-service.service";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loaduser, loaduserdata } from "./userstore.action";
import { map, switchMap } from "rxjs";

@Injectable()
export class getuserapi{
    constructor(private storeserv:StoreServiceService,private action:Actions){}
    loaduser$=createEffect(()=>
    this.action.pipe(
        ofType(loaduser),
        switchMap(()=>this.storeserv.getuserdata().pipe(
            map(users=>loaduserdata({users}))
        ))
    )
    )
}