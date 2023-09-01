import { createAction, props } from "@ngrx/store";
import { user } from "../models/usermodel";

export const loaduser = createAction('loaduser');
export const loaduserdata = createAction('loaduserdata',props<{users:user[]}>())
