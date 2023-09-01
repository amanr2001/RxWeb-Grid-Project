import { createAction, props } from "@ngrx/store";
import { order } from "../models/ordermodel";

export const loadorder = createAction('loadorder')
export const loadordersuccess = createAction('loadordersuccess',props<{orders:order[]}>())