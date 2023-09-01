import { createAction, props } from "@ngrx/store";
import { sellcar, upddata } from "../models/sellcarmodel";

export const loaddata = createAction('loaddata');
export const loaddatasuccess = createAction('loaddatasuccess',props<{sellcars:sellcar[]}>());
    export const updatedata = createAction('updatedata',props<{carid:number,sellcars:upddata}>());
export const delcarreq = createAction('delcarreq',props<{carid:number}>());
export const denyreq=createAction('denyreq',props<{carid:number}>())