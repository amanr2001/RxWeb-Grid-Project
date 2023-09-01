import { createFeatureSelector, createSelector } from "@ngrx/store";
import { order } from "../models/ordermodel";

export const selectorder = createFeatureSelector<Array<order>>('orders')

export const orderbyuser = (id:number)=>createSelector(selectorder,(orders)=>{
    return orders.filter(x=>x.userid==id)
})
export const ordersarray=createSelector(selectorder,(orders:order[])=>{
    return orders.length
})

