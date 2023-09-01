import { createFeatureSelector, createSelector } from "@ngrx/store";
import { sellcar } from "../models/sellcarmodel";

export const carapproval=createFeatureSelector<Array<sellcar>>('sellcars')
export const carreqlength = createSelector(carapproval,(sellcars)=>{
     return  sellcars.length
})
export const carbyuser=(id:number) => createSelector(carapproval,(sellcars)=>{
     return sellcars.filter(x=>x.userid==id)
})
export const sortcarbystatus= createSelector(carapproval,(sellcars)=>{
     const sorteddata = sellcars.slice();
     sorteddata.sort((a,b)=>a.approval.name.localeCompare(b.approval.name))
     return sorteddata
})

export const sortcarbypricelow= createSelector(carapproval,(sellcars)=>{
     const sorteddata = sellcars.slice();
     sorteddata.sort((a,b)=>a.price - b.price)
     return sorteddata
})
export const sortcarbypricehigh= createSelector(carapproval,(sellcars)=>{
     const sorteddata = sellcars.slice();
     sorteddata.sort((a,b)=>b.price - a.price)
     return sorteddata
})

export const filterdatabyapproved =(name:string)=> createSelector(carapproval,(sellcars)=>{
     return sellcars.filter(x=>x.approval.name===name)
})

// done