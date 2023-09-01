import { createReducer, on } from "@ngrx/store";
import { user } from "../models/usermodel";
import { loaduserdata } from "./userstore.action";

export const inititalstate:Array<user>=[]
export const getuserreducer = createReducer(
    inititalstate,
    on(loaduserdata,(state,{users})=>users)
)