export interface car{
  carid:number;
  carbrand:string;
  carmodel:string;
  price:number;
  location:string;
  cartype:string;
  year:string;
  sellerprice:number;
  createdDate:Date;
  modifiedDate:Date;
  fuel:string;
  kmdriven:number;
  images:img;
  owner:string;
  seats:string;
  city:string;
  status:string;
  loc:string;
  wishl:wishlist
}

export interface img{
  leftside:string;
  rightside:string;
  backview:string;
  frontview:string;
}
export interface wishlist{
  userid:number;
  carid:number;
  wishliststatus:boolean
}

export interface objct{
  petrol:Array<pet>;
  owner:Array<pet>;
  seats:Array<pet>;
  km:Array<pet>;
  modelyear:Array<pet>;
  city:Array<cit>;
}

export interface pet{
  name:string;
  objId:number
}
export interface cit{
  cityid:number;
  cityname:string
}


export interface bookedcar{
  
}