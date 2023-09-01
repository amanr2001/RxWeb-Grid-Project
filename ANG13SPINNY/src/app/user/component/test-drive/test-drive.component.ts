import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { data } from 'jquery';
import { LoaderService } from 'src/services/loader.service';
import { MainservService } from 'src/services/mainserv.service';

@Component({
  selector: 'app-test-drive',
  templateUrl: './test-drive.component.html',
  styleUrls: ['./test-drive.component.css']
})
export class TestDriveComponent implements OnInit{

  testarr:Array<any>=[]
  avail:boolean=false;
  constructor(private demo:MainservService,private http:HttpClient,private loader:LoaderService) {


  }
  p:any;
  ngOnInit(): void {
    this.loader.setFlag(true)
     let i = localStorage.getItem('id')
     this.demo.GetInterestedTestD(i).subscribe(data=>{
      //console.log(data);

      this.testarr=data;
      this.loader.setFlag(false)

     })
     this.loader.setFlag(true)

     this.demo.GetConfirmedTestD(i).subscribe(data=>{
      //console.log(data);
      this.testarr=data
      this.loader.setFlag(false)

     })



  }

  interested(){
    let i = localStorage.getItem('id')
    this.loader.setFlag(true)

     this.demo.GetInterestedTestD(i).subscribe(data=>{
      //console.log(data);

      this.testarr=data;
      this.loader.setFlag(false)


     })
     this.avail=true
  }
  confirmed(){
    let i = localStorage.getItem('id')
    this.loader.setFlag(true)

    this.demo.GetConfirmedTestD(i).subscribe(data=>{
      //console.log(data);
      this.testarr=data
      //console.log(this.testarr);

      this.loader.setFlag(false)

     })
     this.avail=false


  }
  dateformat(st: Date) {
    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var x = new Date(st);
    //console.log(st);
    let res = days[x.getDay()] + ", " + x.getDate() + " " + months[x.getMonth()] + " " + x.getFullYear()
    return res;

  }

}
