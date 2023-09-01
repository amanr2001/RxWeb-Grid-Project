import { createReducer, on } from "@ngrx/store";
import { order } from "../models/ordermodel";
import { loadordersuccess } from "./orderstore.action";

export const initialorderstate:Array<order>=[]

export const getorderreducer = createReducer(
    initialorderstate,
    on(loadordersuccess,(state,{orders})=>orders)
)