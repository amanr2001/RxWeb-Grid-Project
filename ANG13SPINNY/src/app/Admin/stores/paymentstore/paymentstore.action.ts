import { createAction, props } from "@ngrx/store";
import { pay } from "../models/paymentmodel";

export const loadpayment=createAction('loadpayment');
export const loadpaymentsuccess = createAction('loadpaymentsuccess',props<{payment:pay[]}>())
