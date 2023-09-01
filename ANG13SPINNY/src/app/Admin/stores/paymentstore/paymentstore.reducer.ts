import { createReducer, on } from "@ngrx/store";
import { pay } from "../models/paymentmodel";
import { loaddatasuccess } from "../sellrequeststore/store.action";
import { loadpaymentsuccess } from "./paymentstore.action";

export const paymentinitialstate:Array<pay>=[]

export const paymentreducer = createReducer(
    paymentinitialstate,
    on(loadpaymentsuccess,(state,{payment})=>payment)

)