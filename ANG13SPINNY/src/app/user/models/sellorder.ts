export interface sellorder{
  carid:number;
  carbrand:string;
  carmodel:string;
  price:number;
  date:Date;
  modifiedDate:Date;
  location:string;
  cartype:string;
  year:string;
  sellerprice:number;
  kmdriven:number;
  userid:number;
  stat:statusname
}


export interface statusname{
  name:string
}


export interface userdata{
  username:string;
  useremail:string;
}
