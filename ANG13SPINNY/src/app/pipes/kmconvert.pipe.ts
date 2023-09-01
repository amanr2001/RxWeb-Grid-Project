import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'kmconvert'
})
export class KmconvertPipe implements PipeTransform {

  transform(value: number): string {
    if(value>=1000){
      return (value/1000).toString()+'k';
    }
    else{
      return value.toString();
    }
  }

}
