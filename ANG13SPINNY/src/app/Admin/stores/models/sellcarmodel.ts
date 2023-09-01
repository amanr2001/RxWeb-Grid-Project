export interface sellcar{
    carid:number;
    carbrand:string;
    carmodel:string;
    price:number;
    cartype:string;
    year:number;
    kmdriven:number;
    sellerprice:number;
    date:string;
    modifiedDate:string;
    userid:number;
    approval:approved;
    user:userd;
    outlets:Array<string>
}
export interface userd{
    username:string;
    useremail:string
}
export interface approved{
    name:string
}

export interface upddata{
    sellerprice:number
}
