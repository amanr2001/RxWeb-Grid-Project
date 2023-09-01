import { Actions, createEffect, ofType } from "@ngrx/effects";
import { StoreServiceService } from "../services/store-service.service";
import { createoutlets, loadcities, loadcitiessuccess } from "./city.action";
import { switchMap,map, mergeMap } from "rxjs";
import { Injectable } from "@angular/core";
@Injectable()
export class getcity{
    constructor( private storeserv:StoreServiceService,private action:Actions){

    }
    loadcities$ = createEffect(()=>
    this.action.pipe(
        ofType(loadcities),
        switchMap(()=>this.storeserv.getcity().pipe(
            map(city=>loadcitiessuccess({city}))
        ))
    )
    )



    adddata$ = createEffect(() =>
    this.action.pipe(
      ofType(createoutlets),
      mergeMap(({ city }) =>
        this.storeserv.addoutlets(city).pipe(
          map((city) => {
            return loadcities();
          })
        )
      )
    )
  )
}