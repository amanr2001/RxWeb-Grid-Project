import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'src/services/loader.service';
import { MainservService } from 'src/services/mainserv.service';

@Component({
  selector: 'app-bookedcars',
  templateUrl: './bookedcars.component.html',
  styleUrls: ['./bookedcars.component.css']
})
export class BookedcarsComponent implements OnInit{

  constructor(private demo:MainservService,private http:HttpClient,private loader:LoaderService){

  }
  p:any;
  bookedcars:Array<any>=[]
  ngOnInit(): void {
    let i = localStorage.getItem('id')
    this.loader.setFlag(true);
    this.http.get<any>(this.demo.baseurl+'/Orders/'+i).subscribe(data=>{
      console.log(data.orderitem  );
        this.bookedcars=data.orderitem
        this.loader.setFlag(false)
    })

  }

  delcar(id:number){
    //console.log(id);
    this.http.delete(this.demo.baseurl+'/Orders/deletebookedcars/'+id).subscribe({
      next:(data:any)=>{

      },
      error:(err:any)=>{
        alert("Something went Wrong")
      }
    })
    // data=>{
    //   //console.log(data);

    // }
  }
}
