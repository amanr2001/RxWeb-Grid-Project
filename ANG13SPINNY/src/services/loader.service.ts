import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  constructor() { }

  f!:boolean

  get flag(){
    return this.f
  }
  setFlag(b:boolean){
    this.f=b
  }
}
