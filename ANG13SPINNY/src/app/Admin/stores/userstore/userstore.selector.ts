import { createFeatureSelector, createSelector } from "@ngrx/store";
import { user } from "../models/usermodel";

export const selecteduser = createFeatureSelector<Array<user>>('users')
export const userlen = createSelector(selecteduser,(users)=>{
    return users.length
})

export const userbyid=(id:number) => createSelector(selecteduser,(users)=>{
    return users.filter(x=>x.userid==id)
})