import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {

  mainpagedata:any;

  constructor(private route:Router,private serv:MainservService){
   this.serv.getmainpage().subscribe({
      next:(resp:any)=>{
        console.log(resp);
        this.mainpagedata=resp
        
      }
    })
  }
  sellcar(){
    let x = localStorage.getItem('id')
    if(x==null){
      alert("Not Logged In")
      this.route.navigate(['login'])  
    }
    else{
      this.route.navigate(['sell'])
    }
  }

  ArrayGroup<Type>(arg: Array<Type>,n:number) {
    let CourseGroup:Array<Array<Type>>=[]
     for (let i = 0; i < arg.length/n; i++) {
      CourseGroup.push(arg.slice(i*n,(i+1)*n))
      }
     return CourseGroup;
   }

}
