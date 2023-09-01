import { createAction, props } from "@ngrx/store";
import { city } from "../models/citymodel";

export const loadcities = createAction('loadcities');
export const loadcitiessuccess = createAction('loadcitiessuccess',props<{city:city[]}>())
export const createoutlets = createAction('createoutlets',props<{city:city}>())