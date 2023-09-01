export interface sellcarmodel{
  Carbrand:string;
  Carmodel:string;
  Price:string;
  Modelyear:Date;
  Fueltype:number;
  Owner:number;
  Seats:number;
  Location:string;
  Cartype:string;
  Cityid:number;
  Kmdriven:number;
  Frontview:string;
  Leftside:string;
  Rightside:string;
  Backview:string;
}

export interface filterobj{
  cars:string[];
  year:string;
  Fuel:string[];
  kms:string;
}
