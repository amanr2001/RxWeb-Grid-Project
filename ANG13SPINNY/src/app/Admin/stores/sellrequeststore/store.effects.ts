import { Injectable } from "@angular/core";
import { StoreServiceService } from "../services/store-service.service";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { delcarreq, denyreq, loaddata, loaddatasuccess, updatedata } from "./store.action";
import { map, mergeMap, switchMap } from "rxjs";

@Injectable()
export class getapi{

    constructor(private storeserv:StoreServiceService,private action:Actions){}
    // loadcarrequest
    loaddata$=createEffect(()=>
        this.action.pipe(
            ofType(loaddata),
            switchMap(()=>this.storeserv.getsellreq().pipe(
                map(sellcars=>loaddatasuccess({sellcars}))
            ))
        )
    )
    // updcarrequest
    upddata$=createEffect(()=>
        this.action.pipe(
            ofType(updatedata),
            mergeMap(({carid,sellcars})=>
            this.storeserv.updatecardata(carid,sellcars).pipe(
                map((sellcars)=>{
                    return loaddata();
                })
            )
            )
        )
    )
    denyreq$=createEffect(()=>
        this.action.pipe(
            ofType(denyreq),
            mergeMap(({carid})=>
            this.storeserv.denyreq(carid).pipe(
                map((sellcars)=>{
                    return loaddata();
                })
            )
            )
        )
    )

    // delcarrequest

    delcarrequest$=createEffect(()=>
    this.action.pipe(
        ofType(delcarreq),
        mergeMap(({carid})=>
        this.storeserv.delcarreq(carid).pipe()  
        )
    ),
    {dispatch:false}
    )



}