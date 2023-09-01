import { createReducer, on } from "@ngrx/store";
import { sellcar } from "../models/sellcarmodel";
import { delcarreq, denyreq, loaddatasuccess, updatedata } from "./store.action";

export const initialsellstate:Array<sellcar> = []
export const getreducer = createReducer(
    initialsellstate,
    on(loaddatasuccess,(state,{sellcars})=>sellcars),
    on(updatedata,(state,{carid,sellcars})=>{
        const updated = state.map(b=>(b.carid==carid ? sellcars:b))
        return {...state,updated}
    }),
    on(denyreq,(state,{carid})=>{
        const updated = state.map(b=>(b.carid==carid ))
        return {...state,updated}
    }),
    on(delcarreq,(state,{carid})=>state.filter(x=>x.carid!=carid))
)