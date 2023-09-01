import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';
import { sellorder } from '../../models/sellorder';
import { LoaderService } from 'src/services/loader.service';

@Component({
  selector: 'app-sell-orders',
  templateUrl: './sell-orders.component.html',
  styleUrls: ['./sell-orders.component.css']
})
export class SellOrdersComponent implements OnInit {
  sellorder: Array<sellorder> = []
  p:any;
  constructor(private demo: MainservService, private fb: FormBuilder, private http: HttpClient, private router: Router,private loader:LoaderService) {


  }

  ngOnInit(): void {
    let i = localStorage.getItem('id')
    this.loader.setFlag(true)
    this.demo.CarSellReq(i).subscribe(data => {
      //console.log(data);
      this.sellorder = data;
      //console.log(this.sellorder);
      this.loader.setFlag(false)
    })
  }

  dateformat(st: Date) {
    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var x = new Date(st);
    //console.log(st);
    let res = days[x.getDay()] + ", " + x.getDate() + " " + months[x.getMonth()] + " " + x.getFullYear()
    return res;

  }
  cancelid!: number;
  cancelreq(i: number) {
    this.cancelid = i
  }

  cancel() {
    this.loader.setFlag(true)

    this.demo.DelSellReq(this.cancelid).subscribe({
      next: (data: any) => {
        //console.log(data);
        let i = localStorage.getItem('id')
        this.demo.CarSellReq(i).subscribe(dat => {
          //console.log(data);
          this.sellorder = dat;
          //console.log(this.sellorder);
          
        })
        this.loader.setFlag(false)
      },
      error:(err:any)=>{
        
        this.loader.setFlag(false)

      }
    })

    // data=>{
      
      window.location.reload()
    // }
  }

}
