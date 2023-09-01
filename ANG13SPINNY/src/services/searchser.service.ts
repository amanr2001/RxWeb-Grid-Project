import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SearchserService {

  constructor() { }

  data:any
  searchdata(data:string){
    this.data=data

  }

}
