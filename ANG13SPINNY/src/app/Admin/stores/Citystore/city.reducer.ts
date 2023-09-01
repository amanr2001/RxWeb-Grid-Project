import { createReducer, on } from "@ngrx/store";
import { city } from "../models/citymodel";
import { createoutlets } from "./city.action";

export const initialcitystate:Array<city>=[]


export const cityreducer = createReducer(
    initialcitystate,
    on(createoutlets,(state,{city})=>[...state,city])
)