import { car } from "src/app/user/models/carsdata";

export interface order{
    orderid:number;
    userid:number;
    count:number;
    orderitem:Array<ord>
}

export interface ord{
    orderid:number;
    cars:carsdata
}
export interface carsdata{
    carid:number;
    carbrand:string;
    carmodel:string;
    price:number;
    cartype:string;
    year:number;
    kmdriven:string;
    sellerprice:number;
    createdDate:string;
    modifiedDate:string;
    fuel:string;
    city:string;

}